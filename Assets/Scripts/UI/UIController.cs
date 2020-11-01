using UnityEngine;

[DisallowMultipleComponent]
public class UIController : MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private PlayerDeathView playerDeathView = null;

    public static UIController Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerDeathView.gameObject.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        playerDeathView.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
