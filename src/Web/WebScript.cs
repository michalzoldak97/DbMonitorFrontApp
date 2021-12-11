using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace D1
{
    public class WebScript : MonoBehaviour
    {
        protected bool isActionInProgress;
        protected void FinishWebProcess()
        {
            isActionInProgress = false;
            Destroy(this);
        }
    }
}
