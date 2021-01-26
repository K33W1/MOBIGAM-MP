using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
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

    public void ScreenshotAndUpload()
    {
        if (FB.IsLoggedIn)
        {
            StartCoroutine(ScreenshotAndUploadCoroutine());
        }
        else
        {
            Debug.LogWarning("Tried to screenshot and upload but " +
                             "user is not logged in!");
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

    private IEnumerator ScreenshotAndUploadCoroutine()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] screenshotPNG = screenshot.EncodeToPNG();

        WWWForm form = new WWWForm();
        form.AddBinaryData("image", screenshotPNG, "screenshot.png");
        form.AddField("caption", "Screenshot");
        FB.API("me/photos", HttpMethod.POST, OnUploadPhotoFinished, form);

        Debug.Log("Uploading image...");
    }

    private void OnUploadPhotoFinished(IGraphResult result)
    {
        if (string.IsNullOrEmpty(result.Error))
        {
            Debug.Log($"Uploaded photo with id: {result.ResultDictionary["id"]}");
        }
        else
        {
            Debug.Log($"Error uploading photo. {result.Error}");
        }
    }

    protected override void SingletonOnDestroy()
    {

    }
}
