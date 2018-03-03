using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
namespace FBAuthKit.Example
{

    public class FacebookUIManager : MonoBehaviour
    {

        public GameObject facebookController, statusText;

        void Start()
        {
            facebookController.GetComponent<FacebookAuthController>().Register(gameObject);
        }

        void OnAuthSuccess(AccessToken token)
        {
            statusText.GetComponent<Text>().text = token.UserId;
        }

        void OnInitializedFailure()
        {
            statusText.GetComponent<Text>().text = "App Initialization Failure";
        }

        void OnAuthRequest()
        {
            statusText.GetComponent<Text>().text = "Authenticating";
        }

        void OnAuthFailure()
        {
            statusText.GetComponent<Text>().text = "Authentication Failure";
        }

    }

}
