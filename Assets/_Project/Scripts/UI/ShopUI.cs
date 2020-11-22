using System.Collections.Generic;
using System.Linq;
using Kiwi.DataObject;
using UnityEngine;

[DisallowMultipleComponent]
public class ShopUI : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private IntValue money = null;

    [Header("References")]
    [SerializeField] private ShopItemUI shopItemUIPrefab = null;
    [SerializeField] private RectTransform shopItemsTransform = null;

    [Header("Settings")]
    [SerializeField] private List<ShopItemData> shopItemSettings = null;

    private void Awake()
    {
        List<ShopItemUI> shopItems =
            shopItemsTransform.GetComponentsInChildren<ShopItemUI>().ToList();

        while (shopItems.Count < shopItemSettings.Count)
        {
            ShopItemUI newShopItemUI = Instantiate(shopItemUIPrefab, shopItemsTransform);
            shopItems.Add(newShopItemUI);
        }

        while (shopItems.Count > shopItemSettings.Count)
        {
            int index = shopItems.Count - 1;
            Destroy(shopItems[index].gameObject);
            shopItems.RemoveAt(index);
        }

        for (int i = 0; i < shopItemSettings.Count; i++)
        {
            shopItems[i].Initialize(this, shopItemSettings[i]);
        }
    }

    public void BuyShopItem(ShopItemData data)
    {
        if (money.Value >= data.Price)
        {
            Debug.Log("Buying " + data.ItemName);
            data.PerformUpgrade();
            money.Value -= data.Price;
        }
        else
        {
            OnNotEnoughMoney(data);
        }
    }

    private void OnNotEnoughMoney(ShopItemData data)
    {
        Debug.Log("Not enough money! " +
                  "Money: " + money.Value +
                  " | Price: " + data.Price);
    }
}
