using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class BossAnimator : MonoBehaviour
{
    private Animator animator = null;
    private Health health = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

        health.Died += OnBossDeath;
    }

    private void OnBossDeath()
    {
        animator.SetTrigger("Died");
    }
}
