using UnityEngine;

[CreateAssetMenu(fileName = "New Animation Curve Config", menuName = "Configs/Animation Curve")]
public class AnimationCurveConfig : ScriptableObject
{
    [SerializeField] private AnimationCurve curve = null;
    [SerializeField, Min(0)] private float duration = 1f;

    public AnimationCurve Curve => curve;
    public float Duration => duration;
}
