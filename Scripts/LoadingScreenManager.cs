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

            var operation = SceneManager.LoadSceneAsync(info.Scene.name);

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
