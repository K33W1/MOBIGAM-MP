using Kiwi.DataObject;
using UnityEngine;

[DisallowMultipleComponent]
public class LevelManager : MonoBehaviour
{
    private IntValue levelScore = null;

    private void Awake()
    {
        levelScore = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Level Score");
    }

    private void Start()
    {
        levelScore.Value = 0;
    }

    private void OnDestroy()
    {
        levelScore.Value = 0;
    }
}
