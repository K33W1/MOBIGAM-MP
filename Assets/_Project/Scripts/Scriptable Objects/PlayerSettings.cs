using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("References")]
    [SerializeField] private FloatValue fireRate = null;
    [SerializeField] private FloatValue moveSpeed = null;
    [SerializeField] private FloatValue bulletSpeed = null;

    public float FireRate => fireRate.Value;
    public float MoveSpeed => moveSpeed.Value;
    public float BulletSpeed => bulletSpeed.Value;
}
