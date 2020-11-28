using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Shooting Config", menuName = "Configs/Enemy Shooting")]
public class EnemyShootingConfig : ScriptableObject
{
    [SerializeField, Range(0, 1)] private float shootChance = 0.5f;
    [SerializeField, Min(0)] private float shootCooldown = 2f;
    [SerializeField, Min(0)] private float attemptShootRate = 1f;
    [SerializeField, Min(0)] private float bulletSpeed = 10f;
    [SerializeField, Min(0)] private float startShootingDelay = 1f;

    public float ShootChance => shootChance;
    public float ShootCooldown => shootCooldown;
    public float AttemptShootRate => attemptShootRate;
    public float BulletSpeed => bulletSpeed;
    public float StartShootingDelay => startShootingDelay;
}
