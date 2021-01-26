using System;
using System.Collections.Generic;
using Facebook.Unity;
using Kiwi.Core;
using UnityEngine;

public class FacebookManager : MonoBehaviourSingleton<FacebookManager>
{
    [SerializeField] private List<string> permissions = new List<string>
    {
        "public_profile",
        "email"
    };

    public event Action<IDictionary<string, object>> GetUserDataSuccessful;

    public bool IsLoggedIn { get; private set; } = false;
    public IDictionary<string, object> UserData { get; private set; }

    protected override void SingletonAwake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(OnFacebookInitialized, OnFacebookHidden);
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void Login()
    {
        if (!FB.IsInitialized)
        {
            Debug.LogError("Tried to login to Facebook but it is not yet initialized!");
            return;
        }

        if (!FB.IsLoggedIn)
        {
            FB.LogInWithReadPermissions(permissions, OnFacebookLoginFinished);
        }
        else
        {
            Debug.LogWarning("Facebook user already logged in!");
            IsLoggedIn = true;
        }
    }

    private void OnFacebookInitialized()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("FB Initialized.");
        }
        else
        {
            Debug.LogError("FB Initialize failed!");
        }
    }

    private void OnFacebookHidden(bool shown)
    {
        if (shown)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void OnFacebookLoginFinished(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("User logged in.");

            IsLoggedIn = true;
            GetUserData();
        }
        else
        {
            Debug.LogError("User failed to login!");
        }
    }

    private void GetUserData()
    {
        string query = "/me?fields=name,email";
        FB.API(query, HttpMethod.GET, OnGetUserDataFinished);
    }

    private void OnGetUserDataFinished(IGraphResult result)
    {
        if (string.IsNullOrEmpty(result.Error))
        {
            UserData = result.ResultDictionary;
            GetUserDataSuccessful?.Invoke(result.ResultDictionary);
        }
        else
        {
            Debug.LogError("Error getting Facebook user data!");
        }
    }

    protected override void SingletonOnDestroy()
    {

    }
}
