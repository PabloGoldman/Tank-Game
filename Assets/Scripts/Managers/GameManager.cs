namespace Game
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public GameSettings gameSettings;

        bool inEndGameScreen;

        public bool InEndGameScreen
        {
            get { return inEndGameScreen; }
        }

        int score;

        public int Score
        {
            get { return score; }
        }

        public void AddScore()
        {
            score++;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void GameOver()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}


