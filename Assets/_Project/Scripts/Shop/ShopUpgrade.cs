using UnityEngine;

public abstract class ShopUpgrade : ScriptableObject
{
    public abstract int Price { get; }

    public abstract void ApplyUpgrade();
}
