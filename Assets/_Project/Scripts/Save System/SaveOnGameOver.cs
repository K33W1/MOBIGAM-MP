using Kiwi.Events;
using UnityEngine;

public class SaveOnGameOver : MonoBehaviour
{
    private SaveSystem saveSystem = null;
    private GameEvent gameOver = null;

    private void Awake()
    {
        saveSystem = AssetBundleManager.Instance.GetAsset<SaveSystem>("configs", "Save System");
        gameOver = AssetBundleManager.Instance.GetAsset<GameEvent>("configs", "Game Over");
    }

    private void OnEnable()
    {
        gameOver.RegisterListener(Save);
    }

    private void Save()
    {
        saveSystem.Save();
    }

    private void OnDisable()
    {
        gameOver.UnregisterListener(Save);
    }
}
