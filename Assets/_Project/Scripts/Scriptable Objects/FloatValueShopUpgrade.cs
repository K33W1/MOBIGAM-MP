using UnityEngine;

[CreateAssetMenu(fileName = "New FloatValue Shop Upgrade", menuName = "Shop/FloatValue Upgrade")]
public class FloatValueShopUpgrade : ShopUpgrade
{
    [SerializeField] private FloatValue floatValueToUpgrade = null;
    [SerializeField] private float upgradeAmount = 1f;

    public override void PerformUpgrade()
    {
        floatValueToUpgrade.Value += upgradeAmount;
    }
}
