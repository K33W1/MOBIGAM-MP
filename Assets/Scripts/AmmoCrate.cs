using UnityEngine;

[DisallowMultipleComponent]
public class AmmoCrate : MonoBehaviour, IDamageHandler
{
    [Header("Settings")]
    [SerializeField] private Element element = Element.Blue;
    [SerializeField] private Vector2 bonusAmmoMult = new Vector2(1, 2);
    
    private PlayerShootingOld playerShooting = null;

    public void Initialize(PlayerShootingOld playerShootingOld)
    {
        this.playerShooting = playerShootingOld;
    }

    public void Damage(DamageInfo _)
    {
        float randomBonusAmmoMult = Random.Range(bonusAmmoMult.x, bonusAmmoMult.y);
        playerShooting.TakeAmmoCrateDrop(new AmmoCrateDrop(element, randomBonusAmmoMult));
        Destroy(gameObject);
    }
}
