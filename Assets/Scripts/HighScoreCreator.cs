using TMPro;
using UnityEngine;

namespace Game
{
    public class HighScoreCreator : MonoBehaviour
    {
        SaveLoadGame saveLoad;

        [SerializeField] TMP_Text finalScore;
        [SerializeField] HighScoreTable highScoreTable;

        int score;

        private void Awake()
        {
            saveLoad = new SaveLoadGame();
            score = GameManager.Get().Score;
        }

        // Start is called before the first frame update
        private void Start()
        {
            SetHighScores();
            GameManager.Get().ResetScore();
        }

        private void SetHighScores()
        {
            finalScore.text = "Score: " + score;

            HighScoreEntry actualScore = new HighScoreEntry(score); //Le pasamos el score

            highScoreTable.LoadData(saveLoad); //Cargas la lista de highScores

            highScoreTable.highScoreList.Add(actualScore); //Le añadis el score a la lista

            saveLoad.SaveHighScoresData(highScoreTable.highScoreList); //Guardo la lista

            highScoreTable.LoadData(saveLoad); //Volves a cargar la lista

            highScoreTable.CreateHighScorePanel();
        }
    }
}


