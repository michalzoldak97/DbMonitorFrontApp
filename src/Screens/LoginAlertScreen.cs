using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace D1
{
    public class LoginAlertScreen : MonoBehaviour, IAlertScreen
    {
        public void ProceedCancelAction()
        {
            gameObject.SetActive(false);
        }
        public void ProceedConfirmAction()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
            Debug.Log("Quit");
        }
    }
}
