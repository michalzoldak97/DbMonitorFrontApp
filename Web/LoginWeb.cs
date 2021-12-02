using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace D1
{
    public class LoginWeb : MonoBehaviour
    {
        private LoginVerifier loginVerifier = new LoginVerifier();
        private bool isLogInProgress = false;

        private IEnumerator SendLogIn(string email, string pass, Screen origin)
        {
            string jsonData = "{\n    \"email\": \"" + email + "\",\n    \"password\": \"" + pass + "\"\n}";
            yield return new WaitForSeconds(1f);
            Debug.Log(jsonData);
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
                StartCoroutine(SendLogIn(email, pass, origin));
                return "Succes: Attempt started";
            }
        }
    }
}
