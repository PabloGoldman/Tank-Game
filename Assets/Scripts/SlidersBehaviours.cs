using UnityEngine;
using UnityEngine.UI;

public class SlidersBehaviours : MonoBehaviour
{
    ILoaderSaver loaderSaver;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Awake()
    {
        loaderSaver = new AudioSaveLoad();
    }

    void Start()
    {
        float musicVolume;
        float sfxVolume;

        loaderSaver.GetVolume(out musicVolume, out sfxVolume);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    private void OnApplicationQuit()
    {
        loaderSaver.SetVolume(musicSlider.value, sfxSlider.value);
    }
}
