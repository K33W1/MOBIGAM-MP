using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class Shop : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private IntValue money = null;

    [Header("References")]
    [SerializeField] private ShopItem shopItemPrefab = null;
    [SerializeField] private RectTransform shopItemsTransform = null;

    [Header("Settings")]
    [SerializeField] private List<ShopItemSettings> shopItemSettings = null;

    private void Awake()
    {
        List<ShopItem> shopItems =
            shopItemsTransform.GetComponentsInChildren<ShopItem>().ToList();

        Debug.Assert(shopItems.Count <= shopItemSettings.Count);

        while (shopItems.Count < shopItemSettings.Count)
        {
            ShopItem newShopItem = Instantiate(shopItemPrefab, shopItemsTransform);
            shopItems.Add(newShopItem);
        }

        for (int i = 0; i < shopItemSettings.Count; i++)
        {
            shopItems[i].Initialize(this, shopItemSettings[i]);
        }
    }

    public void BuyShopItem(ShopItemSettings settings)
    {
        if (money.Value >= settings.Price)
        {
            settings.ObjectToUpgrade.Value += settings.UpgradeAmount;
            money.Value -= settings.Price;
        }
        else
        {
            OnNotEnoughMoney(settings);
        }
    }

    private void OnNotEnoughMoney(ShopItemSettings settings)
    {
        Debug.Log("Not enough money! " +
                  "Money: " + money.Value +
                  " | Price: " + settings.Price);
    }
}
