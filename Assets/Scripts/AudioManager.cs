using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip mainMenuBGM;
    public AudioClip click1;
    public AudioClip click2;
    public AudioClip click3;
    public AudioClip click4;

    void Start()
    {
        BGMSource.clip = mainMenuBGM;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
