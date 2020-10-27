using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class AddScoreOnDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue stageScore = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private int scoreToAdd = 100;

    private void Awake()
    {
        Debug.Assert(stageScore != null);

        Health health = GetComponent<Health>();
        health.Died += () => stageScore.Value += scoreToAdd;
    }
}
