using UnityEngine;

[DisallowMultipleComponent]
[CreateAssetMenu(fileName = "New Shop Item Settings", menuName = "Shop Item Settings")]
public class ShopItemSettings : ScriptableObject
{
    [SerializeField] private FloatValue objectToUpgrade = null;
    [SerializeField] private float upgradeAmount = 1f;
    [SerializeField] private string itemName = "Placeholder Name";
    [SerializeField] private int price = 10;

    public FloatValue ObjectToUpgrade => objectToUpgrade;
    public float UpgradeAmount => upgradeAmount;
    public string ItemName => itemName;
    public int Price => price;
}
