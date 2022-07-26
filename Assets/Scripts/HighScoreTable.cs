using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//https://www.youtube.com/watch?v=iAbaqGYdnyI&ab_channel=CodeMonkey

namespace Game
{
    //Representa un high score
    [System.Serializable]
    public class HighScoreEntry
    {
        public int score;

        public HighScoreEntry(int score)
        {
            this.score = score;
        }
    }

    public class HighScoreTable : MonoBehaviour
    {
        [SerializeField] Transform entryContainer;
        [SerializeField] Transform entryTemplate;

        public List<HighScoreEntry> highScoreList;

        public void LoadData(SaveLoadGame saveLoad)
        {
            highScoreList = saveLoad.LoadHighScoresData().highScoreList;
            
            entryTemplate.gameObject.SetActive(false);

            SortHighScores();

            for (int i = 0; i < highScoreList.Count; i++)
            {
                CreateHighScore(highScoreList[i], entryContainer, i + 1);
            }
        }

        private void SortHighScores()
        {
            for (int i = 0; i < highScoreList.Count; i++)
            {
                for (int j = i + 1; j < highScoreList.Count; j++)
                {
                    if (highScoreList[j].score > highScoreList[i].score)
                    {
                        HighScoreEntry temp = highScoreList[i];
                        highScoreList[i] = highScoreList[j];
                        highScoreList[j] = temp;
                    }
                }
            }
        }

        private void CreateHighScore(HighScoreEntry entry, Transform container, int pos)
        {
            float templateHeight = 50f;

            Transform entryTransform = Instantiate(entryTemplate, container); //Creamos un template, hijo del container

            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * (pos - 1));

            //Agarramos el primer hijo, que es la posicion y le asignamos el valor de su posicion
            entryTransform.GetChild(0).GetComponent<TMP_Text>().text = pos.ToString();

            entryTransform.GetChild(1).GetComponent<TMP_Text>().text = entry.score.ToString();

            entryTransform.gameObject.SetActive(true);
        }
    }


}


