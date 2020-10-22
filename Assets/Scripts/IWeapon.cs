using UnityEngine;

public interface IWeapon
{
    void StartFire(Ray ray);
    void StopFire();
}
