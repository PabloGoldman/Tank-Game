using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class SceneManager : MonoBehaviour
    {
        public UnityEvent onChangeScene;

        public void ChangeScene(int sceneIndex)
        {
            onChangeScene?.Invoke();
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);

            if (sceneIndex == 0)
            {
                GameManager.Get().ResetScore();
            }
        }

        public void ReloadScene()
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}


