using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class HighScoresData
    {
        public List<HighScoreEntry> highScores;

        public HighScoresData(List<HighScoreEntry> highScores)
        {
            this.highScores = highScores;
        }
    }
}


