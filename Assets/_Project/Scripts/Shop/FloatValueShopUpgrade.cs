using Kiwi.DataObject;
using UnityEngine;

[CreateAssetMenu(fileName = "New FloatValue Shop Upgrade", menuName = "Shop/FloatValue Upgrade")]
public class FloatValueShopUpgrade : ShopUpgrade
{
    [SerializeField] private FloatValue toUpgrade = null;
    [SerializeField] private int price = 0;
    [SerializeField] private float upgradeValue = 0f;

    public override int Price => price;
    public float UpgradeValue => upgradeValue;

    public override void ApplyUpgrade()
    {
        toUpgrade.Value = upgradeValue;
    }
}
