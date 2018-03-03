using UnityEngine;
using Facebook.Unity;
using PublisherKit;

namespace FBAuthKit
{
    public class FacebookAuthController : Publisher
    {

        public string[] permissions;

        #region Unity Behaviour
        void Awake()
        {
            InitFacebookSDKConnection();
        }
        #endregion

        #region Initialize SDK
        void InitFacebookSDKConnection()
        {
            if (!FB.IsInitialized) FB.Init(OnInitSuccess, OnHideUnity);
            else
            {
                FB.ActivateApp();
                Broadcast("OnAuthSuccess", AccessToken.CurrentAccessToken);
            }
        }

        void OnInitSuccess()
        {
            if (FB.IsInitialized) FB.ActivateApp();
            else Broadcast("OnInitializedFailure");
        }

        void OnHideUnity(bool isGameShown)
        {
            if (!isGameShown) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
        #endregion

        #region Auth
        public void Auth()
        {
            Broadcast("OnAuthRequest");
            FB.LogInWithReadPermissions(permissions, AuthCallback);
        }

        void AuthCallback(ILoginResult result)
        {
            if (FB.IsLoggedIn)
            {
                AccessToken token = AccessToken.CurrentAccessToken;
                Broadcast("OnAuthSuccess", token);
            }
            else
            {
                Broadcast("OnAuthFailure");
            }
        }
        #endregion

    }

}
