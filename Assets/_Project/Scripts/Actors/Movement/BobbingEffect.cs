using UnityEngine;

[DisallowMultipleComponent]
public class BobbingEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform anchorObject = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float xLength = 1f;
    [SerializeField, Min(0)] private float yLength = 1f;
    [SerializeField, Min(0)] private float xSpeed = 1f;
    [SerializeField, Min(0)] private float ySpeed = 1f;

    private float xTimeOffset = 0f;
    private float yTimeOffset = 0f;

    private void Start()
    {
        xTimeOffset = Random.Range(-10000, 10000);
        yTimeOffset = Random.Range(-10000, 10000);
    }

    private void Update()
    {
        float newX = Mathf.Sin((xTimeOffset + Time.time) * xSpeed) * xLength;
        float newY = Mathf.Cos((yTimeOffset + Time.time) * ySpeed) * yLength;

        anchorObject.localPosition = new Vector3
        (
            newX,
            newY,
            0
        );
    }
}
