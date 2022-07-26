using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        SaveLoadGame saveLoad;

        public GameSettings gameSettings;

        public UnityEvent onScoreChanged;
        public UnityEvent onGameOver;

        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject gamePanel;

        [SerializeField] HighScoreTable highScoreTable;

        int score;

        public int Score
        {
            get { return score; }
        }

        private void Start()
        {
            saveLoad = new SaveLoadGame();
        }

        public void AddScore()
        {
            score++;
            onScoreChanged?.Invoke();
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Score: " + score;

            gamePanel.SetActive(false);
            Time.timeScale = 0;

            HighScoreEntry actualScore = new HighScoreEntry(score); //Le pasamos el score


            highScoreTable.LoadData(saveLoad);

            highScoreTable.highScoreList.Add(actualScore); //Lo creo

            saveLoad.SaveHighScoresData(highScoreTable.highScoreList); //Guardo la lista

            highScoreTable.LoadData(saveLoad); //Le paso el valor

            highScoreTable.CreateHighScorePanel();

            //onGameOver?.Invoke();
        }
    }
}


