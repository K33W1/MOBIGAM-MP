﻿using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int DeathID = Animator.StringToHash("Death");

    private Animator animator = null;
    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();

        health.Died += OnDeath;
    }

    private void OnDeath()
    {
        animator.SetTrigger(DeathID);
    }
}
