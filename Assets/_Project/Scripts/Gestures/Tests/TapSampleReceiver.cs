using UnityEngine;

public class TapSampleReceiver : MonoBehaviour
{
    [SerializeField] private GameObject[] toSpawnPrefabs = null;

    private int index = 0;

    private void Start()
    {
        GestureManager.Instance.OnTap += Spawn;
    }

    private void Spawn(object sender, TapEventArgs e)
    {
        if (e.TappedObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(e.TapPosition);
            GameObject toSpawn = toSpawnPrefabs[index];
            index = (index + 1) % toSpawnPrefabs.Length;
            Instantiate(toSpawn, ray.GetPoint(5f), Quaternion.identity);
        }
        else
        {
            Debug.Log($"Hit {e.TappedObject.name}!");
        }
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnTap -= Spawn;
    }
}
