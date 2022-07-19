using UnityEngine;

namespace Game
{
    public class SceneManager : MonoBehaviour
    {
        public void ChangeScene(int sceneIndex)
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
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


