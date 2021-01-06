using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class AsteroidPooler : ObjectPooler<Asteroid>
{
    protected override void InitializeObject(Asteroid obj)
    {
        // Do nothing
    }
}
