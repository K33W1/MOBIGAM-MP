using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerReticle : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private ElementDataObject playerElementDataObject = null;

    [Header("Settings")]
    [SerializeField] private Color elementAColor = Color.red;
    [SerializeField] private Color elementBColor = Color.green;
    [SerializeField] private Color elementCColor = Color.blue;

    private Image reticleImage = null;

    private void Awake()
    {
        reticleImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        playerElementDataObject.ValueChanged += PlayerElementChanged;
    }

    private void PlayerElementChanged(Element element)
    {
        if (element == Element.A)
        {
            reticleImage.color = elementAColor;
        }
        else if (element == Element.B)
        {
            reticleImage.color = elementBColor;
        }
        else
        {
            reticleImage.color = elementCColor;
        }
    }

    private void OnDisable()
    {
        playerElementDataObject.ValueChanged -= PlayerElementChanged;
    }
}
