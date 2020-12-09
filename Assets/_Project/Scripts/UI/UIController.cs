using System.Collections.Generic;
using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class UIController : MonoBehaviourSingleton<UIController>
{
    [Header("Settings")]
    [SerializeField] private View startingView = null;

    public View CurrentView { get; private set; }
    public View LastView { get; private set; }
    
    private List<View> views = new List<View>();

    protected override void SingletonAwake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if (child.TryGetComponent(out View view))
            {
                views.Add(view);
                view.Showed += OnViewShow;
            }
        }
    }

    private void Start()
    {
        foreach (View view in views)
        {
            view.Initialize();
            view.Hide();
        }

        if (startingView == null)
            return;

        CurrentView = startingView;
        CurrentView.Show();
    }

    private void OnViewShow(View showedView)
    {
        if (showedView == CurrentView)
            return;

        foreach (View view in views)
        {
            if (showedView != view)
            {
                view.Hide();
            }
        }

        LastView = CurrentView;
        CurrentView = showedView;
    }

    public void ShowLastView()
    {
        if (LastView == null)
            return;

        foreach (View view in views)
        {
            view.Hide();
        }

        LastView.Show();
        LastView = null;
    }

    protected override void SingletonOnDestroy()
    {

    }
}
