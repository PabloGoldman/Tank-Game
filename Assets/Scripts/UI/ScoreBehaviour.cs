using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreBehaviour : MonoBehaviour
    {
        TMP_Text textField;

        void Start()
        {
            textField = GetComponent<TMP_Text>();
        }

        public void SetScore()
        {
            textField.text = "Score: " + GameManager.Get().Score;
        }
    }
}
