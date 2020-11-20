using UnityEngine;

namespace Kiwi.Audio
{
    [CreateAssetMenu(fileName = "New Audio Event", menuName = "Audio Event")]
    public class AudioEvent : ScriptableObject
    {
        [Header("Playable clips")]
        [SerializeField] private AudioClip[] audioClips = null;

        [Header("Settings")]
        [SerializeField, Range(0, 1)] private float volume = 1f;

        public void Play(AudioSource audioSource)
        {
            int audioClipIndex = Random.Range(0, audioClips.Length);
            AudioClip clipToPlay = audioClips[audioClipIndex];
            audioSource.PlayOneShot(clipToPlay, volume);
        }
    }
}
