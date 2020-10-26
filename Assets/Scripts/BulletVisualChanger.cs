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

    private void Awake()
    {

    }

    public void OnElementChanged(Element element)
    {
        switch (element)
        {
            case Element.None: meshRenderer.material = noneMaterial; break;
            case Element.Red: meshRenderer.material = redMaterial; break;
            case Element.Green: meshRenderer.material = greenMaterial; break;
            case Element.Blue: meshRenderer.material = blueMaterial; break;
        }
    }
}
