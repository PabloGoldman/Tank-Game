using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

namespace Game
{
    public class SaveLoadGame
    {
        public SaveLoadGame()
        {
            string path = Application.persistentDataPath + "/TankGame.dat";

            if (!File.Exists(path))
            {
                List<HighScoreEntry> tempList = new List<HighScoreEntry>();

                BinaryFormatter formatter = new BinaryFormatter();

                FileStream stream = new FileStream(path, FileMode.Create);

                HighScoresData data = new HighScoresData(tempList);

                formatter.Serialize(stream, data);

                stream.Close();
            }
        }

        public void SaveHighScoresData(List<HighScoreEntry> highScoreEntryList)
        {
            string path = Application.persistentDataPath + "/TankGame.dat";

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            HighScoresData data = new HighScoresData(highScoreEntryList);

            formatter.Serialize(stream, data);

            stream.Close();
        }

        public HighScoresData LoadHighScoresData()
        {
            string path = Application.persistentDataPath + "/TankGame.dat";

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


