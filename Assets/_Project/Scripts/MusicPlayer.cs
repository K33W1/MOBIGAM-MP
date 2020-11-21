using UnityEngine;

[DisallowMultipleComponent]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }
}
