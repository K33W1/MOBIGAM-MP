using UnityEngine;

[DisallowMultipleComponent]
public class StageManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue levelScore = null;
    [SerializeField] private IntValue stageScore = null;

    public static StageManager Instance { get; private set; }

    private void Awake()
    {
        Debug.Assert(levelScore != null);
        Debug.Assert(stageScore != null);

        Instance = this;
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
        Instance = null;
    }
}
