using UnityEngine;

public class Debris : MonoBehaviour
{
    private void OnDisable()
    {
        if (DebrisPooler.Instance == null)
            return;

        DebrisPooler.Instance.ReturnToPool(this);
    }
}
