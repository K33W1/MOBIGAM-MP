using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFiringButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerInput playerInput = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerInput.StartFiring();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerInput.StopFiring();
    }
}
