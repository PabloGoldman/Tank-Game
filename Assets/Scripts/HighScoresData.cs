using System.Collections.Generic;

namespace Game
{
    [System.Serializable]
    public class HighScoresData
    {
        public List<HighScoreEntry> highScoreList;

        public HighScoresData(List<HighScoreEntry> highScores)
        {
            highScoreList = highScores;
        }
    }
}


