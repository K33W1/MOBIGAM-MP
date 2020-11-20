using Kiwi.Audio;
using UnityEngine;

[DisallowMultipleComponent]
public class ExplosionAudioPlayer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("Audio Event References")]
    [SerializeField] private AudioEvent onEnableAudio = null;

    private void OnEnable()
    {
        onEnableAudio.Play(audioSource);
    }
}
