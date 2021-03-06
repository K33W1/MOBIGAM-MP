﻿using Kiwi.DataObject;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class WinView : View
{
    [Header("Data Objects")]
    [SerializeField] private IntValue levelScore = null;
    [SerializeField] private IntValue money = null;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI moneyText = null;
    [SerializeField] private WatchAdButton watchAdButton = null;
    [SerializeField] private PostToFacebookButton fbButton = null;

    private void OnEnable()
    {
        AdManager.Instance.AdFinished += OnAdFinished;
    }

    private void OnAdFinished(object sender, AdFinishEventArgs e)
    {
        Refresh();
    }

    protected override void OnShow()
    {
        Refresh();
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            watchAdButton.Disable();
            fbButton.Disable();
        }
        else
        {
            watchAdButton.Enable();
            fbButton.Enable();
        }
    }

    public void Refresh()
    {
        scoreText.text = levelScore.Value.ToString().PadLeft(6, '0');
        moneyText.text = money.Value.ToString().PadLeft(4, '0');
    }

    protected override void OnHide()
    {

    }

    private void OnDisable()
    {
        if (AdManager.Instance != null)
            AdManager.Instance.AdFinished -= OnAdFinished;
    }
}
