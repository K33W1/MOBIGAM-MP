using UnityEngine;

[DisallowMultipleComponent]
public class Boss : MonoBehaviour
{
    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
