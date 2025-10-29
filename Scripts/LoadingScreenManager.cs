using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Generalisk.LoadingScreen
{
    public class LoadingScreenManager : MonoBehaviour
    {
        public void Load() => StartCoroutine(Sequence());

        private IEnumerator Sequence()
        {
            var info = FindFirstObjectByType<LoadingInfo>();

            DontDestroyOnLoad(this);

            AsyncOperation operation;

            if (info.SceneIndex != -1)
            { operation = SceneManager.LoadSceneAsync(info.SceneIndex); }
            else if (info.SceneName != string.Empty)
            { operation = SceneManager.LoadSceneAsync(info.SceneName); }
            else { operation = SceneManager.LoadSceneAsync(info.Scene.name); }

            while (!operation.isDone)
            {
                info.Progress = operation.progress / .9f;
                yield return null;
            }

            if (info.deleteObject)
            { Destroy(info.gameObject); }
            else { Destroy(info); }

            Destroy(gameObject);
        }
    }
}
