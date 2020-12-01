using System;
using UnityEngine;

[DisallowMultipleComponent]
public class DisableOnPlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision _)
    {
        if (gameObject.TryGetComponent(out PlayerDamageHandler _))
        {
            gameObject.SetActive(false);
        }
    }
}