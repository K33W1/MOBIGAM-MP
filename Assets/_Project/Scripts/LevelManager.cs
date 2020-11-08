using UnityEngine;

[DisallowMultipleComponent]
public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue levelScore = null;
    [SerializeField] private IntValue stageScore = null;

    private void Awake()
    {
        Debug.Assert(levelScore != null);
        Debug.Assert(stageScore != null);
    }

    private void Start()
    {
        levelScore.Value = 0;
        stageScore.Value = 0;
    }

    private void OnDestroy()
    {
        levelScore.Value = 0;
        stageScore.Value = 0;
    }
}
