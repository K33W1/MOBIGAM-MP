using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        ExplosionPooler.Instance.ReturnToPool(this);
    }
}
