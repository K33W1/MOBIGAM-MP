using System;
using Random = UnityEngine.Random;

public static class ElementExtensions
{
    private static readonly Element[] AllElements = Enum.GetValues(typeof(Element)) as Element[];
    private static readonly Element[] ValidElements = GetAllValidElements();

    public static Element GetRandomValidElement()
    {
        return ValidElements[Random.Range(0, ValidElements.Length)];
    }

    private static Element[] GetAllValidElements()
    {
        Element[] allElements = Enum.GetValues(typeof(Element)) as Element[];
        Element[] validElements = new Element[AllElements.Length - 1];
        
        for (int i = 0; i < allElements.Length - 1; i++)
        {
            validElements[i] = allElements[i + 1];
        }

        return validElements;
    }
}