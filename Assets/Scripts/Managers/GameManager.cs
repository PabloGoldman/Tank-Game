using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public UnityEvent onScoreChanged;
        public UnityEvent onGameOver;

        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject gamePanel;

        int score;

        public int Score
        {
            get { return score; }
        }

        public void AddScore()
        {
            score++;
            onScoreChanged?.Invoke();
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
            gamePanel.SetActive(false);
            Time.timeScale = 0;

            onGameOver?.Invoke();
        }
    }
}


