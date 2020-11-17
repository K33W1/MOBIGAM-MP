using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("References")]
    [SerializeField] private FloatValue fireRateValue = null;
    [SerializeField] private FloatValue moveSpeed = null;
    [SerializeField] private FloatValue bulletSpeed = null;

    public FloatValue FireRateValue => fireRateValue;
    public FloatValue MoveSpeed => moveSpeed;
    public FloatValue BulletSpeed => bulletSpeed;
}
