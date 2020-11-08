using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class AddScoreOnDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue levelScore = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private int scoreToAdd = 100;

    private void Awake()
    {
        Health health = GetComponent<Health>();
        health.Died += () => levelScore.Value += scoreToAdd;
    }
}
