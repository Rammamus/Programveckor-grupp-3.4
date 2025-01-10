using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;
    public AudioClip whip;

    private void Start()
    {
        sfxSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayWhipSound()
    {
        sfxSource.PlayOneShot(whip);
    }

}
