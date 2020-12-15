using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ShopItemUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI itemNameText = null;
    [SerializeField] private TextMeshProUGUI priceText = null;

    private ShopUI shopUI = null;
    private ShopItem shopItem = null;

    public void Initialize(ShopUI shopUI, ShopItem shopItem)
    {
        this.shopUI = shopUI;
        this.shopItem = shopItem;

        UpdateUI();
    }

    public void Buy()
    {
        shopUI.BuyShopItem(shopItem);

        UpdateUI();
    }

    private void UpdateUI()
    {
        itemNameText.text = shopItem.ItemName + " Lv. " + shopItem.CurrentLevel;
        priceText.text = shopItem.Price.ToString();
    }
}
