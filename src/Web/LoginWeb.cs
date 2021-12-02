using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace D1
{
    public class LoginWeb : MonoBehaviour
    {
        private Screen reqOrigin;
        private LoginVerifier loginVerifier = new LoginVerifier();
        private bool isLogInProgress = false;

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
            yield return new WaitForSeconds(1f);
        }
        public string LoginAttempt(string email, string pass, Screen origin)
        {
            if (isLogInProgress)
                return "Error: Login is in progress";
            else
                isLogInProgress = true;

            if (!loginVerifier.IsLoginInputValid(email, pass))
            {
                return "Error: Input data format is not valid";
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
