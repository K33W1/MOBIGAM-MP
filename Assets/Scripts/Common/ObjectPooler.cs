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
            T[] startingObjects = GetComponentsInChildren<T>();

            foreach (T obj in startingObjects)
            {
                pool.Enqueue(obj);
            }

            for (int i = pool.Count; i < amountToPool; i++)
            {
                pool.Enqueue(CreateObject());
            }
        }

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
            pool.Enqueue(obj);
        }

        private T CreateObject()
        {
            T obj = Instantiate(objToPoolPrefab);
            obj.transform.parent = transform;
            obj.gameObject.SetActive(false);
            return obj;
        }
    }
}
