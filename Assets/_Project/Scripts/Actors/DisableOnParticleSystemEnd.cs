using UnityEngine;

[DisallowMultipleComponent]
public class DisableOnParticleSystemEnd : MonoBehaviour
{
    private new ParticleSystem particleSystem = null;

    private float timer = 0;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > particleSystem.main.duration)
        {
            gameObject.SetActive(false);
        }
    }
}
