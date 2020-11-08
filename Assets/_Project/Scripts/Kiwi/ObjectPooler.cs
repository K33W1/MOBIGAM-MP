using System.Collections.Generic;
using UnityEngine;

namespace Kiwi.Common
{
    public abstract class ObjectPooler<T> : MonoBehaviour where T : Component
    {
        [Header("References")]
        [SerializeField] private T objToPoolPrefab = null;

        [Header("Settings")]
        [SerializeField] private int amountToPool = 4;
        [SerializeField] private bool isExpandable = false;

        public static ObjectPooler<T> Instance { get; private set; }
        
        private readonly Queue<T> pool = new Queue<T>();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            T[] children = GetComponentsInChildren<T>();

            foreach (T child in children)
            {
                InitializeObject(child);

                if (!child.gameObject.activeSelf)
                {
                    pool.Enqueue(child);
                }
            }

            for (int i = children.Length; i < amountToPool; i++)
            {
                T obj = CreateObject();
                obj.gameObject.SetActive(false);
            }
        }

        protected abstract void InitializeObject(T obj);

        public T GetPooledObject()
        {
            if (pool.Count > 0)
            {
                T obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }

            if (isExpandable)
            {
                T obj = CreateObject();
                obj.gameObject.SetActive(true);
                return obj;
            }

            return null;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }

        private T CreateObject()
        {
            T obj = Instantiate(objToPoolPrefab);
            InitializeObject(obj);
            obj.transform.parent = transform;
            return obj;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}
