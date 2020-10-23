using UnityEngine;

namespace Kiwi.Common
{
    [DisallowMultipleComponent]
    public class LifetimeTimer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float maxLifetime = 25f;

        float timeElapsed = 0f;

        private void OnEnable()
        {
            timeElapsed = 0f;
        }

        private void Update()
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= maxLifetime)
                gameObject.SetActive(false);
        }
    }
}
