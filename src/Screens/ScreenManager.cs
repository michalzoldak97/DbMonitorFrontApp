using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace D1
{
    public class ScreenManager : MonoBehaviour
    {
        private IEnumerator LoadASceneAsync(int idx)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(idx);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        public void SwitchScreen(Screens idx)
        {
            StartCoroutine(LoadASceneAsync((int)idx));
        }
    }
}
