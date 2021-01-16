using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFiringButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerInput playerInput = null;

    public void Initialize(PlayerInput playerInput)
    {
        this.playerInput = playerInput;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerInput.StartFiring();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerInput.StopFiring();
    }
}
