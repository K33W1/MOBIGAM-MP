using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
public class DebrisAudioPlayer : MonoBehaviour
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
