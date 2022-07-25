using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//https://www.youtube.com/watch?v=iAbaqGYdnyI&ab_channel=CodeMonkey

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] Transform entryContainer;

    [SerializeField] Transform entryTemplate;

    private List<HighScoreEntry> highScoreEntryList;

    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry(10, "Pabluwu"),
            new HighScoreEntry(5, "Sofiuwu"),
            new HighScoreEntry(2, "uwu")
        };

        highScoreEntryTransformList = new List<Transform>();

        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScore(highScoreEntry, entryContainer, highScoreEntryTransformList);   
        }
    }

    private void CreateHighScore(HighScoreEntry entry, Transform container, List<Transform> transformList)
    {
        int pos = transformList.Count + 1;

        float templateHeight = 50f;

        Transform entryTransform = Instantiate(entryTemplate, entryContainer); //Creamos un template, hijo del container

        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);

        entryTransform.GetChild(0).GetComponent<TMP_Text>().text = pos.ToString(); //Agarramos el primer hijo, que es la posicion y le asignamos el valor de su posicion
        entryTransform.GetChild(1).GetComponent<TMP_Text>().text = entry.score.ToString();
        entryTransform.GetChild(2).GetComponent<TMP_Text>().text = entry.name.ToString();

        entryTransform.gameObject.SetActive(true);

        transformList.Add(entryTransform);
    }

    //Representa un high score
    private class HighScoreEntry
    {
        public int score;
        public string name;

        public HighScoreEntry(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
    }

}
