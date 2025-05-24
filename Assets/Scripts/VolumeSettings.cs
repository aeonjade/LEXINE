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
    [SerializeField] private AudioClip testSFX; // Add this field for test sound


    private bool isMusicMuted = false;
    private bool isSFXMuted = false;
    private bool isAdjusting = false;
    private bool isInitializing = false;



    void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            float SFXVolume = SFXSlider.value;
            audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
            PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
        }
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
        PlayerPrefs.SetFloat("BGMVolume", BGMVolume);
    }

    public void SetSFXVolume()
    {
        float SFXVolume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

        // Play test sound only if not initializing and not muted
        if (!isInitializing && !isAdjusting && !isSFXMuted)
        {
            SFXSource.PlayOneShot(testSFX);
            isAdjusting = true;
            Invoke("ResetAdjusting", 0.75f);
        }
    }

    private void LoadVolume()
    {
        isInitializing = true;

        // Set BGM
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SetMusicVolume();

        // Set SFX without playing test sound
        float SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        SFXSlider.value = SFXVolume;
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);

        isInitializing = false;

    }

    private void ResetAdjusting()
    {
        isAdjusting = false;
    }
}
