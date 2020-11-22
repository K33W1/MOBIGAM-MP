using UnityEngine;

[DisallowMultipleComponent]
[CreateAssetMenu(fileName = "New Shop Item Data", menuName = "Shop/Item Data")]
public class ShopItemData : ScriptableObject
{
    [Header("References")]
    [SerializeField] private ShopUpgrade shopUpgrade = null;

    [Header("Settings")]
    [SerializeField] private string itemName = "Placeholder Name";
    [SerializeField] private int price = 10;

    public string ItemName => itemName;
    public int Price => price;

    public void PerformUpgrade()
    {
        shopUpgrade.PerformUpgrade();
    }
}
