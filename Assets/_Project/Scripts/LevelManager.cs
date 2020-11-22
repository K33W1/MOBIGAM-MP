using Kiwi.DataObject;
using UnityEngine;

[DisallowMultipleComponent]
public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue levelScore = null;

    private void Start()
    {
        levelScore.Value = 0;
    }

    private void OnDestroy()
    {
        levelScore.Value = 0;
    }
}
