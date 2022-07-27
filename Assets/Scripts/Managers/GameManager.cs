using TMPro;
using UnityEngine;
using UnityEngine.Events;

//AÑADIR PARTICULAS AL DISPARAR, AL MOVERSE ETC
//AÑADIR ANIMACIONES A LA UI

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

            SetHighScores();

            onGameOver?.Invoke();
        }

        private void SetHighScores()
        {
            HighScoreEntry actualScore = new HighScoreEntry(score); //Le pasamos el score

            highScoreTable.LoadData(saveLoad); //Cargas la lista de highScores

            highScoreTable.highScoreList.Add(actualScore); //Le añadis el score a la lista

            saveLoad.SaveHighScoresData(highScoreTable.highScoreList); //Guardo la lista

            highScoreTable.LoadData(saveLoad); //Volves a cargar la lista

            highScoreTable.CreateHighScorePanel();
        }
    }
}


