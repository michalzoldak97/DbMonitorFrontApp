using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace D1
{
    public class LoginScreen : Screen
    {
        [SerializeField] private TMP_InputField emailInputField, passInputField;
        [SerializeField] private Button logInButton;
        [SerializeField] private TMP_Text warnText;
        [SerializeField] private GameObject frameCloseAlert;

        public void EnableCancelAlert()
        {
            frameCloseAlert.SetActive(true);
        }

        public void OnFieldChanged()
        {
            AreInputsFilled();
        }
        private bool AreInputsFilled()
        {
            if (passInputField.text.Length > 7 && emailInputField.text.Length > 1)
            {
                logInButton.interactable = true;
                return true;
            }
            else
            {
                logInButton.interactable = false;
                return false;
            }
        }
        private void Start()
        {
            InitialSetUp();
            AreInputsFilled();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) && AreInputsFilled())
            {
                LogInAttempt();
            }
        }
        private IEnumerator DisplayMessage(string msg)
        {
            warnText.text = msg;
            logInButton.interactable = false;
            yield return new WaitForSeconds(2);
            logInButton.interactable = true;
            warnText.text = "";
        }
        public void LogInAttempt()
        {
            LoginWeb loginWeb = gameObject.AddComponent<LoginWeb>() as LoginWeb;
            string[] resText = loginWeb.LoginAttempt(emailInputField.text, passInputField.text, this).Split(':');
            if (resText[0] == "Error")
            {
                StartCoroutine(DisplayMessage(resText[1]));
                Destroy(loginWeb);
            }
        }
        public void ReceiveResponse(LoginResponse res)
        {
            if (res.status == null || res.status.Split(':')[0] == "error")
            {
                StartCoroutine(DisplayMessage("Login failed"));
            }
            else
            {
                globalSettings.SetToken(res.token);
                StartCoroutine(DisplayMessage(res.status));
                screenManager.SwitchScreen(Screens.Base);
            }
        }
    }
}
