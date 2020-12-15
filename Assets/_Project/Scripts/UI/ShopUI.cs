using System.Collections.Generic;
using System.Linq;
using Kiwi.DataObject;
using UnityEngine;

[DisallowMultipleComponent]
public class ShopUI : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private Shop shop = null;
    [SerializeField] private IntValue money = null;

    [Header("References")]
    [SerializeField] private ShopItemUI shopItemUIPrefab = null;
    [SerializeField] private RectTransform shopItemsTransform = null;

    private void Awake()
    {
        List<ShopItemUI> shopItemUI =
            shopItemsTransform.GetComponentsInChildren<ShopItemUI>().ToList();

        while (shopItemUI.Count < shop.Items.Count)
        {
            ShopItemUI newShopItemUI = Instantiate(shopItemUIPrefab, shopItemsTransform);
            shopItemUI.Add(newShopItemUI);
        }

        while (shopItemUI.Count > shop.Items.Count)
        {
            int index = shopItemUI.Count - 1;
            Destroy(shopItemUI[index].gameObject);
            shopItemUI.RemoveAt(index);
        }

        for (int i = 0; i < shop.Items.Count; i++)
        {
            shopItemUI[i].Initialize(this, shop.Items[i]);
        }
    }

    public void BuyShopItem(ShopItem data)
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

    private void OnNotEnoughMoney(ShopItem data)
    {
        Debug.Log("Not enough money! " +
                  "Money: " + money.Value +
                  " | Price: " + data.Price);
    }
}
