using System;
using UnityEngine;

public interface IWeapon
{
    void StartFire(Func<Ray> aimGetterFunc);
    void StopFire();

    Element Element { get; set; }

    void TakeBonusAmmo(float bonusAmmoMult);
}
