using System;

public interface IDamageHandler
{
    event Action UndamagedHit;
    event Action Damaged;

    void Damage(DamageInfo damage);
}
