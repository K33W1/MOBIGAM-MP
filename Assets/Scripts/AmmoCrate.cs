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
    [Header("Settings")]
    [SerializeField] private Element element = Element.Blue;
    [SerializeField] private Vector2 bonusAmmoMult = new Vector2(1, 2);
    
    private PlayerShooting playerShooting = null;

    public void Initialize(PlayerShooting playerShooting)
    {
        this.playerShooting = playerShooting;
    }

    public void Damage(DamageInfo _)
    {
        float randomBonusAmmoMult = Random.Range(bonusAmmoMult.x, bonusAmmoMult.y);
        playerShooting.TakeAmmoCrateDrop(new AmmoCrateDrop(element, randomBonusAmmoMult));
        Destroy(gameObject);
    }
}
