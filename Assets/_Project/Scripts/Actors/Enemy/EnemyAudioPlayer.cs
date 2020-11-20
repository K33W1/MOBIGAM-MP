using Kiwi.Audio;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnemyShooting))]
public class EnemyAudioPlayer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("Audio Event References")]
    [SerializeField] private AudioEvent onShotFiredAudio = null;

    private void Awake()
    {
        Health health = GetComponent<Health>();
        EnemyShooting shooting = GetComponent<EnemyShooting>();
        shooting.ShotFired += () => onShotFiredAudio.Play(audioSource);
    }
}
