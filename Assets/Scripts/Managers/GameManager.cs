using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public GameSettings gameSettings;

        public UnityEvent onScoreChanged;
        public UnityEvent onGameOver;

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
            onScoreChanged?.Invoke();
        }

        public void GameOver()
        {
            onGameOver?.Invoke();
        }
    }
}


