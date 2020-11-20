using UnityEngine;

[DisallowMultipleComponent]
public class BulletVisualChanger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer meshRenderer = null;

    [Header("Materials")]
    [SerializeField] private Material noneMaterial = null;
    [SerializeField] private Material redMaterial = null;
    [SerializeField] private Material greenMaterial = null;
    [SerializeField] private Material blueMaterial = null;

    public void OnElementChanged(Element element)
    {
        switch (element)
        {
            case Element.None: meshRenderer.material = noneMaterial; break;
            case Element.A: meshRenderer.material = redMaterial; break;
            case Element.B: meshRenderer.material = greenMaterial; break;
            case Element.C: meshRenderer.material = blueMaterial; break;
        }
    }
}
