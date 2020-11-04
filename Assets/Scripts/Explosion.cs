using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    private void OnDisable()
    {
        ExplosionPooler.Instance.ReturnToPool(this);
    }
}
