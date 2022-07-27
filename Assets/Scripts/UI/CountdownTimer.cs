using TMPro;
using UnityEngine.Events;
using UnityEngine;

//https://www.youtube.com/watch?v=o0j7PdU88a4&ab_channel=SingleSaplingGames

namespace Game
{
    public class CountdownTimer : MonoBehaviour
    {
        public UnityEvent onReachTime;
        public UnityEvent onTimeDown;

        TMP_Text textField;

        float currentTime = 0;

        private void Start()
        {
            currentTime = GameManager.Get().gameSettings.startingTime;
            textField = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            currentTime -= 1 * Time.deltaTime;

            textField.text = "Time Remaining: " + currentTime.ToString("0");

            if (currentTime < 0)
            {
                onReachTime?.Invoke();
            }
        }
    }
}

