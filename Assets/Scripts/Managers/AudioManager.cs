using UnityEngine;

namespace Game
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [SerializeField] AudioSource shootSound;
        [SerializeField] AudioSource buttonSound;

        public void PlayShootSound()
        {
            shootSound.Play();
        }

        public void PlayButtonSound()
        {
            buttonSound.Play();
        }
    }
}

