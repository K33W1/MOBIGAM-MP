using UnityEngine;

namespace Kiwi.Common
{
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-1000)]
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected abstract void SingletonAwake();
        protected abstract void SingletonOnDestroy();

        private T thisInstance = null;

        private void Awake()
        {
            thisInstance = GetComponent<T>();

            if (Instance == null)
            {
                Instance = thisInstance;
            }
            else if (thisInstance != Instance)
            {
                Destroy(gameObject);
                return;
            }

            SingletonAwake();
        }

        private void OnDestroy()
        {
            if (Instance != thisInstance)
                return;

            Instance = null;
            SingletonOnDestroy();
        }
    }
}
