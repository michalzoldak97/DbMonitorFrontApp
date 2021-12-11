using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace D1
{
    public class StartScreen : Screen
    {
        [SerializeField] private TMP_Text warnText;
        private IEnumerator DisplayMessage(string msg)
        {
            warnText.text = msg;
            yield return new WaitForSeconds(2);
            warnText.text = "";
        }
        private void ReadGeneralAccess()
        {
            if (globalSettings.token != null) 
            {
                StartWeb startWeb = gameObject.AddComponent<StartWeb>() as StartWeb;
                startWeb.FetchGeneralAccess(this, globalSettings.token);
            }
            else
            {
                StartCoroutine(DisplayMessage("Authorizaton Fail"));
            }
        }
        void Start()
        {
            InitialSetUp();
            ReadGeneralAccess();
        }
        public void ReceiveResponse(GeneralAccessResponse res)
        {
            if (res.message == null || res.message.Split(':')[0] == "error")
            {
                StartCoroutine(DisplayMessage(res.message.Split(':')[1]));
            }
        }
    }
}
