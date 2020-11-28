using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class DisableMonoBehaviourOnDeath : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] monoBehaviours = null;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();

        health.Died += OnDeath;
    }

    private void OnDeath()
    {
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            monoBehaviour.enabled = false;
        }
    }
}
