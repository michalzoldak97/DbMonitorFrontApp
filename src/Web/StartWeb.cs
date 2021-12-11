using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace D1
{
    public class StartWeb : WebScript
    {
        // called by start screen
        // should return array o enums -> what access butoons display for the user
        private StartScreen reqOrigin;

        private IEnumerator GetGeneralAccess(string token)
        {
            string url = WebManager.baseUrl + WebManager.startScreenRoute;
            UnityWebRequest accReq = new UnityWebRequest(url, "GET");
            accReq.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            accReq.SetRequestHeader("Authorization", "Bearer " + token);
            yield return accReq.SendWebRequest();
            if (accReq.error != null)
            {
                GeneralAccessResponse resObj = new GeneralAccessResponse();
                resObj.message = "error: " + accReq.error;
                reqOrigin.ReceiveResponse(resObj);
                FinishWebProcess();
            }
            Debug.Log(accReq.downloadHandler.text);
            FinishWebProcess();
        }
        public void FetchGeneralAccess(StartScreen origin, string token)
        {
            reqOrigin = origin;
            StartCoroutine(GetGeneralAccess(token));
        }
    }
}
