using UnityEngine;

namespace Kiwi.Common
{
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected abstract void SingletonAwake();
        protected abstract void SingletonOnDestroy();

        private void Awake()
        {
            T thisInstance = GetComponent<T>();

            if (Instance == null)
            {
                Instance = thisInstance;
                DontDestroyOnLoad(Instance.gameObject);
            }

            else if (thisInstance != Instance)
            {
                Destroy(thisInstance);
                return;
            }

            SingletonAwake();
        }

        private void OnDestroy()
        {
            Instance = null;

            SingletonOnDestroy();
        }
    }
}
