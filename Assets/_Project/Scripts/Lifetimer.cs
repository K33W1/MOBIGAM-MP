using UnityEngine;

[DisallowMultipleComponent]
public class Lifetimer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float duration = 8.0f;

    private float timer = 0f;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
            gameObject.SetActive(false);
    }
}
