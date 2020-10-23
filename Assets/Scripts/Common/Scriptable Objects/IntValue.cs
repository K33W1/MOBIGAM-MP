using UnityEngine;

[CreateAssetMenu(fileName = "New Int Value", menuName = "Common/IntValue")]
public class IntValue : ScriptableObject
{
    [SerializeField] private int value = 0;

    public int Value
    {
        get => value;
        set => this.value = value;
    }
}
