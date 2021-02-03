using Kiwi.DataObject;
using UnityEngine;

public class UnlockAllLevelsButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        IntList unlockedLevels = AssetBundleManager.Instance.GetAsset<IntList>("configs", "Unlocked Levels");

        if (!unlockedLevels.Contains(0))
            unlockedLevels.Add(0);
        if (!unlockedLevels.Contains(1))
            unlockedLevels.Add(1);
        if (!unlockedLevels.Contains(2))
            unlockedLevels.Add(2);
    }
}
