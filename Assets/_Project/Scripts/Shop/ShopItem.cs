using System.Collections.Generic;
using Kiwi.DataObject;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item Data", menuName = "Shop/Item Data")]
public class ShopItem : ScriptableObject
{
    [Header("References")]
    [SerializeField] private List<ShopUpgrade> shopUpgrades = null;

    [Header("Settings")]
    [SerializeField] private string itemName = "Placeholder Name";
    [SerializeField] private IntValue currentLevel = null;

    public ShopUpgrade CurrentUpgrade => shopUpgrades[currentLevel.Value];
    public ShopUpgrade NextUpgrade => shopUpgrades[currentLevel.Value + 1];
    public string ItemName => itemName;
    public int CurrentLevel => currentLevel.Value;

    public int Price => currentLevel.Value + 1 < shopUpgrades.Count
        ? NextUpgrade.Price
        : 0;

    public void ApplyUpgrade()
    {
        CurrentUpgrade.ApplyUpgrade();
    }

    public void PerformUpgrade()
    {
        if (currentLevel.Value + 1 < shopUpgrades.Count)
        {
            currentLevel.Value++;
            CurrentUpgrade.ApplyUpgrade();
        }
        else
        {
            Debug.LogWarning("Can't upgrade any further!");
        }
    }
}
