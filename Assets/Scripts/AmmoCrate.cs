using JetBrains.Annotations;
using UnityEngine;

public struct AmmoCrateDrop
{
    public Element Element;
    public float BonusAmmoMult;

    public AmmoCrateDrop(Element element, float bonusAmmoMult)
    {
        Element = element;
        BonusAmmoMult = bonusAmmoMult;
    }
}

public class AmmoCrate : MonoBehaviour, IDamageHandler
{
    [Header("References")]
    [SerializeField] private PlayerShooting playerShooting = null;

    [Header("Settings")]
    [SerializeField] private Element element = Element.Blue;
    [SerializeField] private Vector2 bonusAmmoMult = new Vector2(1, 2);

    public void Damage(DamageInfo _)
    {
        float randomBonusAmmoMult = Random.Range(bonusAmmoMult.x, bonusAmmoMult.y);
        playerShooting.TakeAmmoCrateDrop(new AmmoCrateDrop(element, randomBonusAmmoMult));
        Destroy(gameObject);
    }
}
