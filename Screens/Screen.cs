using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D1
{
    public class Screen : MonoBehaviour
    {
        protected GlobalSettings globalSettings;
        protected void InitialSetUp()
        {
            globalSettings = GameObject.FindGameObjectWithTag("Player").GetComponent<GlobalSettings>();
        }

    }
}
