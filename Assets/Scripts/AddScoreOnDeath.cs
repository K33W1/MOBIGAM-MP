using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class AddScoreOnDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue stageScore = null;

    [Header("Settings")]
    [SerializeField] private int scoreToAdd = 100;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.Died += () => stageScore.Value += scoreToAdd;
    }
}
