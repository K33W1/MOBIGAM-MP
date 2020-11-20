using Kiwi.Audio;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerShooting))]
public class PlayerAudioPlayer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("Audio Event References")]
    [SerializeField] private AudioEvent onShotFiredAudio = null;

    private void Awake()
    {
        PlayerShooting shooting = GetComponent<PlayerShooting>();

        shooting.ShotFired += () => onShotFiredAudio.Play(audioSource);
    }
}
