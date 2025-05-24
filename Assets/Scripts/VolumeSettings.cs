using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    private bool isMusicMuted = false;
    private bool isSFXMuted = false;

    void Start()
    {
        SetMusicVolume();
        SetSFXVolume();
    }

    public void ToggleMusic()
    {
        isMusicMuted = !isMusicMuted;
        BGMSource.mute = isMusicMuted;

        // Optional: You can also disable the slider when muted
        BGMSlider.interactable = !isMusicMuted;
    }
    public void ToggleSFX()
    {
        isSFXMuted = !isSFXMuted;
        SFXSource.mute = isSFXMuted;

        // Optional: You can also disable the slider when muted
        SFXSlider.interactable = !isSFXMuted;
    }


    public void SetMusicVolume()
    {
        float BGMVolume = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMVolume) * 20);
    }

    public void SetSFXVolume()
    {
        float SFXVolume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
    }
}
