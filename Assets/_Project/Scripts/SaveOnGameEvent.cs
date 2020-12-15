using Kiwi.Events;
using UnityEngine;

public class SaveOnGameEvent : MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem = null;
    [SerializeField] private GameEvent gameEvent = null;

    private void OnEnable()
    {
        gameEvent.RegisterListener(Save);
    }

    private void Save()
    {
        saveSystem.Save();
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(Save);
    }
}
