using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D1
{
    public class GlobalSettings : MonoBehaviour
    {
        private static int targetFrameRate = 120;
        public string token { get; private set; }

        private void SetQuality()
        {
            Application.targetFrameRate = targetFrameRate;
        }
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            WebManager.Launch();
        }
        private void Start()
        {
            SetQuality();
        }
        public void SetToken(string toSet)
        {
            token = toSet;
        }
    }
}
