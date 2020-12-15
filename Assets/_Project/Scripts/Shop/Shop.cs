using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Shop/Shop")]
public class Shop : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] private List<ShopItem> items = null;

    public List<ShopItem> Items => items;

    public void Initialize()
    {
        foreach (ShopItem item in items)
        {
            item.Initialize();
        }
    }
}
