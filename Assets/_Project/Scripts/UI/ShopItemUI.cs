using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ShopItemUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI itemNameText = null;
    [SerializeField] private TextMeshProUGUI priceText = null;

    private ShopUI shopUI = null;
    private ShopItemData data = null;

    public void Initialize(ShopUI shopUI, ShopItemData data)
    {
        this.shopUI = shopUI;
        this.data = data;

        itemNameText.text = data.ItemName;
        priceText.text = data.Price.ToString();
    }

    public void Buy()
    {
        shopUI.BuyShopItem(data);
    }
}
