using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioManagerInstance;
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioMixer audioMixer;
    public AudioClip mainMenuBGM;
    public AudioClip click1;
    public AudioClip click2;
    public AudioClip click3;
    public AudioClip click4;

    void Awake()
    {
        if (AudioManagerInstance == null)
        {
            AudioManagerInstance = this;
        }
        else if (AudioManagerInstance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        BGMSource.clip = mainMenuBGM;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
    public AudioSource GetBGMSource() => BGMSource;
    public AudioSource GetSFXSource() => SFXSource;
    public AudioMixer GetAudioMixer() => audioMixer;


}
