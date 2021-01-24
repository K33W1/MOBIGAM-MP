using System;
using UnityEngine.Advertisements;

public class AdFinishEventArgs : EventArgs
{
    public string PlacementID { get; }
    public ShowResult ShowResult { get; }

    public AdFinishEventArgs(string placementId, ShowResult showResult)
    {
        PlacementID = placementId;
        ShowResult = showResult;
    }
}
