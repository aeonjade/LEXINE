using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings VolumeSettingsInstance;

    [SerializeField] private AudioClip testSFX; // Optional test SFX clip

    private AudioMixer audioMixer;
    private AudioSource BGMSource;
    private AudioSource SFXSource;

    private Toggle BGMToggle;
    private Toggle SFXToggle;
    private Slider BGMSlider;
    private Slider SFXSlider;

    private bool isMusicMuted = false;
    private bool isSFXMuted = false;
    private bool isAdjusting = false;
    private bool isInitializing = false;

    void Awake()
    {
        if (VolumeSettingsInstance == null)
        {
            VolumeSettingsInstance = this;
        }
        else if (VolumeSettingsInstance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Assign UI controls
        AssignControls();

        // Load mute states
        isMusicMuted = PlayerPrefs.GetInt("BGMMuted", 0) == 1;
        isSFXMuted = PlayerPrefs.GetInt("SFXMuted", 0) == 1;

        // Set initial toggle states without triggering events
        BGMToggle.SetIsOnWithoutNotify(!isMusicMuted);
        SFXToggle.SetIsOnWithoutNotify(!isSFXMuted);

        // Apply mute states
        if (BGMSource != null) BGMSource.mute = isMusicMuted;
        if (SFXSource != null) SFXSource.mute = isSFXMuted;

        BGMSlider.interactable = !isMusicMuted;
        SFXSlider.interactable = !isSFXMuted;

        // Load or initialize volume
        if (PlayerPrefs.HasKey("BGMVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            float SFXVolume = SFXSlider.value;
            if (audioMixer != null)
                audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
            PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
        }
    }

    public void AssignControls()
    {
        BGMToggle = GameObject.FindGameObjectWithTag("BGMToggle").GetComponent<Toggle>();
        SFXToggle = GameObject.FindGameObjectWithTag("SFXToggle").GetComponent<Toggle>();
        BGMSlider = GameObject.FindGameObjectWithTag("BGMSlider").GetComponent<Slider>();
        SFXSlider = GameObject.FindGameObjectWithTag("SFXSlider").GetComponent<Slider>();

        // Set up toggle listeners
        BGMToggle.onValueChanged.AddListener(OnBGMToggleChanged);
        SFXToggle.onValueChanged.AddListener(OnSFXToggleChanged);

        // Set up slider listeners
        BGMSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void OnBGMToggleChanged(bool isOn)
    {
        isMusicMuted = !isOn;
        if (BGMSource != null) BGMSource.mute = isMusicMuted;
        BGMSlider.interactable = !isMusicMuted;
        PlayerPrefs.SetInt("BGMMuted", isMusicMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void OnSFXToggleChanged(bool isOn)
    {
        isSFXMuted = !isOn;
        if (SFXSource != null) SFXSource.mute = isSFXMuted;
        SFXSlider.interactable = !isSFXMuted;
        PlayerPrefs.SetInt("SFXMuted", isSFXMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume()
    {
        float BGMVolume = BGMSlider.value;
        if (audioMixer != null) audioMixer.SetFloat("BGM", Mathf.Log10(BGMVolume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", BGMVolume);
    }

    public void SetSFXVolume()
    {
        float SFXVolume = SFXSlider.value;
        if (audioMixer != null)
            audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

        if (!isInitializing && !isAdjusting && !isSFXMuted && SFXSource != null && testSFX != null)
        {
            SFXSource.PlayOneShot(testSFX);
            isAdjusting = true;
            Invoke("ResetAdjusting", 0.5f);
        }
    }

    private void LoadVolume()
    {
        isInitializing = true;

        // Set BGM volume
        float bgm = PlayerPrefs.GetFloat("BGMVolume");
        BGMSlider.value = bgm;
        SetMusicVolume();

        // Set SFX volume without triggering SFX
        float sfx = PlayerPrefs.GetFloat("SFXVolume");
        SFXSlider.value = sfx;
        if (audioMixer != null)
            audioMixer.SetFloat("SFX", Mathf.Log10(sfx) * 20);

        isInitializing = false;
    }

    private void ResetAdjusting()
    {
        isAdjusting = false;
    }
}
