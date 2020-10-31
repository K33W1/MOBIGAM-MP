using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class AddMoneyOnDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue money = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private int moneyToAdd = 5;
    
    private void Awake()
    {
        Health health = GetComponent<Health>();
        health.Died += () => money.Value += moneyToAdd;
    }
}
