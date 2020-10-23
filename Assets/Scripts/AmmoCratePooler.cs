using Kiwi.Common;
using UnityEngine;

public class AmmoCratePooler : ObjectPooler<AmmoCrate>
{
    [Header("Poolable Object Dependencies")]
    [SerializeField] private PlayerShooting playerShooting = null;

    protected override void InitializeObject(AmmoCrate ammoCrate)
    {
        ammoCrate.Initialize(playerShooting);
    }
}
