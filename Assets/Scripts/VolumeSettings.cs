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


    void Start()
    {
        SetMusicVolume();
        float SFXVolume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
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

        // Play test sound only once when starting to adjust
        if (!isAdjusting && !isSFXMuted)
        {
            SFXSource.PlayOneShot(testSFX);
            isAdjusting = true;

            // Reset the flag after a short delay
            Invoke("ResetAdjusting", 1f);
        }
    }

    private void ResetAdjusting()
    {
        isAdjusting = false;
    }
}
