using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SaveSystem saveSystem = null;

    private static GameManager Instance = null;

    private void Awake()
    {
        if (InitializeSingleton())
            return;

        saveSystem.Load();
    }

    private bool InitializeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return true;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        return false;
    }

    private void OnApplicationQuit()
    {
        saveSystem.Save();
    }
}
