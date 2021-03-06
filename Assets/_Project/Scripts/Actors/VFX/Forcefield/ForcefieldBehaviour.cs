﻿using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class ForcefieldBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer forcefieldRenderer = null;

    [Header("Settings")]
    [SerializeField] private AnimationCurveConfig animationCurve = null;

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
        AnimationCurve animationCurve = this.animationCurve.Curve;
        float timer = 0;

        while (timer < this.animationCurve.Duration)
        {
            timer += Time.deltaTime;
            timer = Mathf.Min(timer, this.animationCurve.Duration);
            float value = animationCurve.Evaluate(timer);
            forcefieldRenderer.material.SetFloat(ForcefieldAlpha, value);
            
            yield return null;
        }
    }
}
