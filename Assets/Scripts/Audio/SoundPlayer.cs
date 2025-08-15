using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip errorSound;

    public void PlayError()
    {
        SoundManager.Instance.Play(errorSound);
    }
}