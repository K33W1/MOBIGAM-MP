using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue levelScore = null;
    [SerializeField] private IntValue stageScore = null;

    public static StageManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        stageScore.Value = 0;
    }

    private void OnDestroy()
    {
        stageScore.Value = 0;
    }
}
