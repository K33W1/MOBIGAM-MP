using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class ForcefieldBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer forcefieldRenderer = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float animationDuration = 1f;
    [SerializeField] private AnimationCurve onDamageAnimationCurve = null;

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
        float timer = 0;

        while (timer < animationDuration)
        {
            float value = Mathf.Min(onDamageAnimationCurve.Evaluate(timer), 1f);
            forcefieldRenderer.material.SetFloat(ForcefieldAlpha, value);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
