using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform modelTransform;

    public Transform ModelTransform => modelTransform;
}
