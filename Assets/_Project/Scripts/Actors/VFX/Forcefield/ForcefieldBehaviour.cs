using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class ForcefieldBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer forcefieldRenderer = null;

    [Header("Settings")]
    [SerializeField] private AnimationCurveConfig animation = null;

    private static readonly int ForcefieldAlpha = Shader.PropertyToID("Vector1_A293667E");

    private IDamageHandler damageHandler = null;

    private void Awake()
    {
        damageHandler = GetComponent<IDamageHandler>();

        damageHandler.UndamagedHit += OnUndamagedHit;
    }

    private void Start()
    {
        forcefieldRenderer.material.SetFloat(ForcefieldAlpha, 0f);
    }

    [ContextMenu("Pretend to take hit with no damage")]
    private void OnUndamagedHit()
    {
        StopAllCoroutines();
        StartCoroutine(ForcefieldAnimation());
    }

    private IEnumerator ForcefieldAnimation()
    {
        AnimationCurve animationCurve = animation.Curve;
        float timer = 0;

        while (timer < animation.Duration)
        {
            timer += Time.deltaTime;
            timer = Mathf.Min(timer, animation.Duration);
            float value = animationCurve.Evaluate(timer);
            forcefieldRenderer.material.SetFloat(ForcefieldAlpha, value);
            
            yield return null;
        }
    }
}
