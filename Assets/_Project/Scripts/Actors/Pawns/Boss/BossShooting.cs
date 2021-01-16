using System.Collections;
using Kiwi.Extensions;
using UnityEngine;

[DisallowMultipleComponent]
public class BossShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform projectileSpawnPoint = null;
    [SerializeField] private LayerMask projectileLayer = new LayerMask();

    [SerializeField] private float startDelayDuration = 4f;
    [SerializeField] private float cooldownDuration = 8f;
    [SerializeField] private float burstShotRate = 0.25f;
    [SerializeField] private int burstShotCount = 10;

    private Transform target = null;

    private void OnEnable()
    {
        StartCoroutine(FiringLoop());
    }

    public void Initialize(Transform target)
    {
        this.target = target;
    }

    private IEnumerator FiringLoop()
    {
        yield return new WaitForSeconds(startDelayDuration);

        while (true)
        {
            for (int i = 0; i < burstShotCount; i++)
            {
                HomingProjectile projectile = HomingProjectilePooler.Instance.GetPooledObject();
                projectile.Launch(projectileLayer.MaskToLayer(), projectileSpawnPoint, target);

                yield return new WaitForSeconds(burstShotRate);
            }

            yield return new WaitForSeconds(cooldownDuration);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
