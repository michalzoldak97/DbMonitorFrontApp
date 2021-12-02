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
        private void Start()
        {
            InitialSetUp();
        }
        public void LogInAttempt()
        {
            LoginWeb loginWeb = gameObject.AddComponent<LoginWeb>() as LoginWeb;
            string testText = loginWeb.LoginAttempt(emailInputField.text, passInputField.text, this);
            Debug.Log(testText);
        }
    }
}
