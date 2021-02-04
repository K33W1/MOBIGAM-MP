using Kiwi.DataObject;
using UnityEngine;

[DisallowMultipleComponent]
public class AddMoneyButton : MonoBehaviour
{
    [SerializeField, Min(0)] private int add = 10;

    public void OnButtonClicked()
    {
        IntValue money = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Money");
        money.Value += add;
    }
}
