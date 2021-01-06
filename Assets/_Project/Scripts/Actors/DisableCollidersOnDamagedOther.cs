using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(DamageOtherOnCollision))]
public class DisableCollidersOnDamagedOther : MonoBehaviour
{
    private DamageOtherOnCollision damageOtherOnCollision;
    private Collider[] colliders = null;

    private void Awake()
    {
        colliders = GetComponentsInChildren<Collider>();
        damageOtherOnCollision = GetComponent<DamageOtherOnCollision>();
        damageOtherOnCollision.DamagedOther += DisableAllColliders;
    }

    private void DisableAllColliders()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
