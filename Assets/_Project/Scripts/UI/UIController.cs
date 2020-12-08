using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UIController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private View startingView = null;

    public View CurrentView { get; private set; }
    
    private List<View> views = new List<View>();

    private void Awake()
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

        CurrentView = showedView;
    }
}
