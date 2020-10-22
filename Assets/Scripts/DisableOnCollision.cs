using UnityEngine;

[DisallowMultipleComponent]
public class DisableOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision _)
    {
        gameObject.SetActive(false);
    }
}
