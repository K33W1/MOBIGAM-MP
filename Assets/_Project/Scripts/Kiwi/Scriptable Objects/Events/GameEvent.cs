using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kiwi.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<Action> listeners = new List<Action>();

        public void RegisterListener(Action action)
        {
            listeners.Add(action);
        }

        public void UnregisterListener(Action action)
        {
            listeners.Remove(action);
        }

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; --i)
            {
                listeners[i]();
            }
        }
    }
}
