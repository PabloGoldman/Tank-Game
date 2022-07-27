using UnityEngine;

namespace Game
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [SerializeField] AudioSource shootSound;
        [SerializeField] AudioSource buttonSound;
        [SerializeField] AudioSource gameOverSound;

        public void PlayShootSound()
        {
            shootSound.Play();
        }

        public void PlayButtonSound()
        {
            buttonSound.Play();
        }

        public void PlayGameOverSound()
        {
            gameOverSound.Play();
        }
    }
}

