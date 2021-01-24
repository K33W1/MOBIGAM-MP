using UnityEngine;

[DisallowMultipleComponent]
public class MainMenuInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.Instance.ShowLastView();
        }
    }
}
