using UnityEngine;

public class Debris : MonoBehaviour
{
    private void OnDisable()
    {
        DebrisPooler.Instance.ReturnToPool(this);
    }
}
