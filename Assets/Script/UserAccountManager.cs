using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;


public class UserAccountManager : MonoBehaviour
{
    public static UserAccountManager Instance;

    
    public static UnityEvent OnSignInSuccess = new UnityEvent();
    
    public static UnityEvent<string> OnSignInFailed = new UnityEvent<string>();
    public static UnityEvent<string> OnCreateAccountFailed = new UnityEvent<string>();

    private void Awake()
    {
        Instance = this;
    }
    public void CreateAccount(string username, string emailAddress, string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(
            new RegisterPlayFabUserRequest()
            {
                Email = emailAddress,
                Password = password,
                Username = username,
                RequireBothUsernameAndEmail = true
            },
            response =>
            {
                Debug.Log($"successful account creation : {username} , {emailAddress}");
                SignIn(username, password);
            },
            error =>
            {
                Debug.Log($"unsuccessful account creation: {username} , {emailAddress} \n {error.ErrorMessage}");
                OnCreateAccountFailed.Invoke(error.ErrorMessage);
            }
       );
    }
     public void SignIn(string username , string password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() { 
            Username = username,
            Password = password
        },
         response =>
         {
             Debug.Log($"successful account Login: {username}");
             OnSignInSuccess.Invoke();
         },
            error =>
            {
                Debug.Log($"unsuccessful account Login: {username} \n {error.ErrorMessage}");
                OnSignInFailed.Invoke(error.ErrorMessage);
            }

        );
    }
   
}
