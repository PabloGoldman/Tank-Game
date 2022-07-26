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
        SaveLoadGame saveLoad;

        [SerializeField] Transform entryContainer;
        [SerializeField] Transform entryTemplate;

        private List<HighScoreEntry> highScoreList;

        private void Awake()
        {
            List<HighScoreEntry> highScoreList = new List<HighScoreEntry> {
                new HighScoreEntry(1),
                new HighScoreEntry(2),
                new HighScoreEntry(3)
            };

            saveLoad = new SaveLoadGame(highScoreList);

            saveLoad.SaveHighScoresData();
        }

        private void Start()
        {
            entryTemplate.gameObject.SetActive(false);

            highScoreList = saveLoad.LoadHighScoresData().highScores;

            SortHighScores();

            foreach (HighScoreEntry highScoreEntry in highScoreList)
            {
                CreateHighScore(highScoreEntry, entryContainer, highScoreList);
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

        private void CreateHighScore(HighScoreEntry entry, Transform container, List<HighScoreEntry> highScoreList)
        {
            int pos = highScoreList.Count + 1;

            float templateHeight = 50f;

            Transform entryTransform = Instantiate(entryTemplate, entryContainer); //Creamos un template, hijo del container

            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * highScoreList.Count);

            entryTransform.GetChild(0).GetComponent<TMP_Text>().text = pos.ToString(); //Agarramos el primer hijo, que es la posicion y le asignamos el valor de su posicion
            entryTransform.GetChild(1).GetComponent<TMP_Text>().text = entry.score.ToString();

            entryTransform.gameObject.SetActive(true);
        }
    }


}


