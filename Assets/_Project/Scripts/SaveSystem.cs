using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Save System", menuName = "Save System")]
public class SaveSystem : ScriptableObject
{
    [Header("Data To Save")]
    [SerializeField] private ScriptableObject[] scriptableObjectsToSave = null;

    [ContextMenu("Save")]
    public void Save()
    {
        for (int i = 0; i < scriptableObjectsToSave.Length; i++)
        {
            ScriptableObject objectToSave = scriptableObjectsToSave[i];

            string saveDataPath = GetObjectName(objectToSave);

            // Save file
            string jsonContents = JsonUtility.ToJson(objectToSave, true);
            File.WriteAllText(saveDataPath, jsonContents);
        }

        Debug.Log("Successfully saved!");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        for (int i = 0; i < scriptableObjectsToSave.Length; i++)
        {
            ScriptableObject objectToOverwrite = scriptableObjectsToSave[i];

            // Get path
            string saveDataPath = Application.persistentDataPath + $"/save_{objectToOverwrite.name}.json";

            // Load file
            string jsonContents = File.ReadAllText(saveDataPath);
            JsonUtility.FromJsonOverwrite(jsonContents, objectToOverwrite);
        }

        Debug.Log("Successfully loaded!");
    }

    private string GetObjectName(ScriptableObject objectToSave)
    {
        string objectName = objectToSave
            .name
            .ToLower()
            .Replace(' ', '_');

        // Get path
        string saveDataPath = Application.persistentDataPath + $"/save_{objectName}.json";
        return saveDataPath;
    }
}
