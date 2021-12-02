using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D1
{
    public class Screen : MonoBehaviour
    {
        protected GlobalSettings globalSettings;
        protected ScreenManager screenManager;
        protected void InitialSetUp()
        {
            GameObject sessionObj = GameObject.FindGameObjectWithTag("Player");
            globalSettings = sessionObj.GetComponent<GlobalSettings>();
            screenManager = sessionObj.GetComponent<ScreenManager>();
        }
    }
}
