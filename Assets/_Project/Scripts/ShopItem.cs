using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ShopItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI itemNameText = null;
    [SerializeField] private TextMeshProUGUI priceText = null;

    private Shop shop = null;
    private ShopItemSettings settings = null;

    public void Initialize(Shop shop, ShopItemSettings settings)
    {
        this.shop = shop;
        this.settings = settings;

        itemNameText.text = settings.ItemName;
        priceText.text = settings.Price.ToString();
    }

    public void Buy()
    {
        shop.BuyShopItem(settings);
    }
}
