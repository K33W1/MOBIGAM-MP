using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[CreateAssetMenu(fileName = "New Shop Item Data", menuName = "Shop/Item Data")]
public class ShopItem : ScriptableObject
{
    [Header("References")]
    [SerializeField] private List<ShopUpgrade> shopUpgrades = null;

    [Header("Settings")]
    [SerializeField] private string itemName = "Placeholder Name";
    [SerializeField, Min(0)] private int currentLevel = 0;

    public ShopUpgrade CurrentUpgrade => shopUpgrades[currentLevel];
    public ShopUpgrade NextUpgrade => shopUpgrades[currentLevel + 1];
    public string ItemName => itemName;
    public int CurrentLevel => currentLevel;

    public int Price => currentLevel + 1 < shopUpgrades.Count
        ? NextUpgrade.Price
        : 0;

    public void Initialize()
    {
        CurrentUpgrade.ApplyUpgrade();
    }

    public void PerformUpgrade()
    {
        if (currentLevel + 1 < shopUpgrades.Count)
        {
            currentLevel++;
            CurrentUpgrade.ApplyUpgrade();
        }
        else
        {
            Debug.LogWarning("Can't upgrade any further!");
        }
    }
}
