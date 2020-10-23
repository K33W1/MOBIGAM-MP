using UnityEngine;

namespace Kiwi.Common
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly object Lock = new object();
        protected static T instance;

        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        // Search for existing instance.
                        instance = FindObjectOfType<T>();

                        // Create new instance if one doesn't already exist.
                        if (instance == null)
                        {
                            Debug.LogWarning("No instance of " + typeof(T).ToString() + " Found!");

                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";
                        }
                    }

                    return instance;
                }
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}