using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class HighScoresData
    {
        public List<HighScoreEntry> highScoreList;

        public HighScoresData(List<HighScoreEntry> highScores)
        {
            this.highScoreList = highScores;
        }
    }
}


