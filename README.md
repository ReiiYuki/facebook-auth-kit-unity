# Facebook Authentication Kit for Unity

Facebook Authentication Toolkit for Unity

## Usage

* Add Facebook Auth Controller from `FBAuthKit/Kit/Prefabs/Facebook Auth Controller.prefab` to your Unity scene.

* Setup Permission in Facebook Auth Controller

* Create Facebook Auth subscriber script and put it to scene.

* Call `Auth` method of Facebook Auth Controller to login

## Facebook Auth Subscriber

```cs
using UnityEngine;
using Facebook.Unity;
using FBAuthKit;

public class ExampleFBAuthSubscriber : MonoBehaviour {
    
    public GameObject facebookController;
    
    void Start()
    {
        //Register as subscriber
        facebookController.GetComponent<FacebookAuthController>().Register(gameObject);    
    }

    void OnAuthSuccess(AccessToken token)
    {
        //Do something when authentication is successful.
    }

    void OnInitializedFailure()
    {
        //Do something when Facebook SDK initialization is failure.
    }

    void OnAuthRequest()
    {
        //Do something when waiting process of Facebook Authentication.
    }

    void OnAuthFailure()
    {
        //Do something when authentication is failure.
    }

}
```

## Solution when Facebook.Unity.Setting.dll is duplicate!

1. Close Unity
2. Go to `C:\Program Files\Unity\Editor\Data\PlaybackEngines`
3. Remove `Facebook`
4. Open Unity Project Again
