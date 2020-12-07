using UnityEngine;

public class SampleTapObject2 : MonoBehaviour, IPinchSpreadable, IRotatable
{
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float scaleSpeed = 1f;

    public void OnPinchSpread(PinchSpreadEventArgs args)
    {
        float scaleValue = args.Delta * scaleSpeed / Screen.dpi;

        Vector3 toScale = new Vector3(scaleValue, scaleValue, scaleValue);

        transform.localScale += toScale;
    }

    public void OnRotate(RotateEventArgs args)
    {
        transform.Rotate(Vector3.forward, args.Angle * rotateSpeed);
    }
}
