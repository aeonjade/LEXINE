using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip sfx;

    public void Play()
    {
        AudioManager.Instance.PlaySFX(sfx);
    }
}

