using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

namespace Game
{
    public class SaveLoadGame
    {
        private List<HighScoreEntry> highScoreEntryList;

        string path = Application.persistentDataPath + "/TankGame.dat";

        public SaveLoadGame(List<HighScoreEntry> highScoreEntryList)
        {
            this.highScoreEntryList = highScoreEntryList;
        }

        public void SaveHighScoresData()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            HighScoresData data = new HighScoresData(highScoreEntryList);

            formatter.Serialize(stream, data);

            stream.Close();
        }

        public HighScoresData LoadHighScoresData()
        {
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                HighScoresData data = formatter.Deserialize(stream) as HighScoresData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }
}


