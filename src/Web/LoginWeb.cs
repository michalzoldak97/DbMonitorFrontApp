using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace D1
{
    public class LoginWeb : MonoBehaviour
    {
        private bool isLogInProgress = false;
        private Screen reqOrigin;
        private LoginVerifier loginVerifier = new LoginVerifier();

        private void FinishProcess()
        {
            isLogInProgress = false;
            Destroy(this);
        }

        private byte[] ParseInput(string email, string pass)
        {
            Dictionary<string, string> dictToParse = new Dictionary<string, string>();
            dictToParse.Add("email", email);
            dictToParse.Add("password", pass);
            StringJSONParser jSONParser = new StringJSONParser(dictToParse);
            return jSONParser.StringToRaw();
        }

        private IEnumerator SendLogIn(byte[] reqJSON)
        {
            string url = WebManager.baseUrl + WebManager.logInRoute;
            UnityWebRequest loginReq = new UnityWebRequest(url, "POST");
            loginReq.uploadHandler = (UploadHandler)new UploadHandlerRaw(reqJSON);
            loginReq.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            loginReq.SetRequestHeader("Content-Type", "application/json");
            yield return loginReq.SendWebRequest();
            if (loginReq.error != null)
            {
                LoginResponse resObj = new LoginResponse();
                resObj.status = "error: " + loginReq.error;
                reqOrigin.ReceiveResponse(resObj);
                FinishProcess();
            }
            else
            {
                LoginResponse loginResponse = JsonUtility.FromJson<LoginResponse>(loginReq.downloadHandler.text);
                reqOrigin.ReceiveResponse(loginResponse);
                FinishProcess();
            }
        }
        public string LoginAttempt(string email, string pass, Screen origin)
        {
            if (isLogInProgress)
                return "Error: Login is in progress";
            else
                isLogInProgress = true;

            if (!loginVerifier.IsLoginInputValid(email, pass))
            {
                return "Error: Invalid input";
            }
            else
            {
                reqOrigin = origin;
                StartCoroutine(SendLogIn(ParseInput(email, pass)));
                return "Succes: Attempt started";
            }
        }
    }
}
