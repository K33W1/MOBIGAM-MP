using UnityEngine;

[DisallowMultipleComponent]
public class DisableOnParticleSystemEnd : MonoBehaviour
{
    private ParticleSystem particles = null;

    private float timer = 0;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > particles.main.duration)
        {
            gameObject.SetActive(false);
        }
    }
}
