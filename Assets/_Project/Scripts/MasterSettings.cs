using UnityEngine;

[CreateAssetMenu(fileName = "New Master Settings", menuName = "Master Settings")]
public class MasterSettings : ScriptableObject
{
    [SerializeField] private bool isDebug = false;

    public bool IsDebug => isDebug;
}
