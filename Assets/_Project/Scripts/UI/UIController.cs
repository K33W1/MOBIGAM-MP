using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UIController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private View startingView = null;

    private List<View> views = new List<View>();
    private View currentView = null;

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

        currentView = startingView;
        currentView.Show();
    }

    private void OnViewShow(View showedView)
    {
        if (showedView == currentView)
            return;

        foreach (View view in views)
        {
            if (showedView != view)
            {
                view.Hide();
            }
        }

        currentView = showedView;
    }
}
