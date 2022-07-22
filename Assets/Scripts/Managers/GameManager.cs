namespace Game
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        int score;
        public int Score
        {
            get { return score; }
        }

        public void AddScore()
        {
            score++;
        }
    }
}


