using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreBehaviour : MonoBehaviour
    {
        TMP_Text textField;

        private void Awake()
        {
            textField = GetComponent<TMP_Text>();
        }

        void Start()
        {
            textField.text = "Score: " + GameManager.Get().Score;
        }

        public void SetScore()
        {
            textField.text = "Score: " + GameManager.Get().Score;
        }
    }
}
