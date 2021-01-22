using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        UIController.Instance.ShowLastView();
    }
}
