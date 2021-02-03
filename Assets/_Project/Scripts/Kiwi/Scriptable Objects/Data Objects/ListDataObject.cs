using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDataObject<T> : ScriptableObject, IEnumerable
{
#pragma warning restore 649
    [SerializeField] private List<T> list;

    public T this[int i]
    {
        get => list[i];
        set => list[i] = value;
    }

    public int Count => list.Count;

    public void Add(T obj)
    {
        list.Add(obj);
    }

    public bool Remove(T obj)
    {
        return list.Remove(obj);
    }

    public void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    public bool Contains(T item)
    {
        return list.Contains(item);
    }

    public T Find(Predicate<T> match)
    {
        return list.Find(match);
    }

    public void Clear()
    {
        list.Clear();
    }

    private class MyEnumerator : IEnumerator
    {
        private readonly List<T> List;
        private int position = -1;

        public MyEnumerator(List<T> list)
        {
            List = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < List.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return List[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new MyEnumerator(list);
    }
}
