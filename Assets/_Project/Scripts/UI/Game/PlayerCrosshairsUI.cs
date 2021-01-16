using UnityEngine;

public class PlayerCrosshairsUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform closeTarget = null;
    [SerializeField] private Transform farTarget = null;

    private UIServiceLocator UIServiceLocator => UIServiceLocator.Instance;

    private void LateUpdate()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 closeReticleViewportPos = playerCamera.WorldToViewportPoint(closeTarget.position);
        Vector2 farReticleViewportPos = playerCamera.WorldToViewportPoint(farTarget.position);
        Vector2 closeScreenPos = closeReticleViewportPos * screenSize;
        Vector2 farScreenPos = farReticleViewportPos * screenSize;

        UIServiceLocator.ClosePlayerReticle.position = closeScreenPos;
        UIServiceLocator.FarPlayerReticle.position = farScreenPos;
    }
}
