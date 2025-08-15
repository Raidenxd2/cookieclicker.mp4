using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] Music;
    public AudioSource audioSource;

    void Start()
    {
        SoundManager.Instance.RandomMusic(Music);
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            SoundManager.Instance.RandomMusic(Music);
        }
    }
}