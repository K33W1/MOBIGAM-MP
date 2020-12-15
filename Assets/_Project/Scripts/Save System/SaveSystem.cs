using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Save System", menuName = "Save System")]
public class SaveSystem : ScriptableObject
{
    [Header("Data To Save")]
    [SerializeField] private ScriptableObject[] saveList = null;

    [ContextMenu("Clear Saves")]
    public void ClearSaveFiles()
    {
        for (int i = 0; i < saveList.Length; i++)
        {
            ScriptableObject objectToSave = saveList[i];
            string saveDataPath = GetObjectName(objectToSave);

            if (File.Exists(saveDataPath))
            {
                File.Delete(saveDataPath);
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        for (int i = 0; i < saveList.Length; i++)
        {
            ScriptableObject objectToSave = saveList[i];
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
        for (int i = 0; i < saveList.Length; i++)
        {
            ScriptableObject objectToOverwrite = saveList[i];
            string saveDataPath = GetObjectName(objectToOverwrite);

            // Load file
            if (File.Exists(saveDataPath))
            {
                string jsonContents = File.ReadAllText(saveDataPath);
                JsonUtility.FromJsonOverwrite(jsonContents, objectToOverwrite);
            }
        }

        Debug.Log("Successfully loaded!");
    }

    private string GetObjectName(ScriptableObject scriptableObject)
    {
        string objectName =
            scriptableObject
            .name
            .ToLower()
            .Replace(' ', '_');

        return Application.persistentDataPath + $"/save_{objectName}.json";
    }
}
