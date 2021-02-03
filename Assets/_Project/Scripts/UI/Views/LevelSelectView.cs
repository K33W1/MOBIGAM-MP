using Kiwi.DataObject;
using UnityEngine;

public class LevelSelectView : View
{
    [SerializeField] private LevelSelectMenu levelSelectMenu = null;

    protected override void OnShow()
    {
        levelSelectMenu.Refresh();
    }

    protected override void OnHide()
    {

    }
}
