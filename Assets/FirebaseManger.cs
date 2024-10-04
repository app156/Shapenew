using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Threading.Tasks;

public class FirebaseManger : MonoBehaviour
{
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;
    // Start is called before the first frame update

    //void Awake()
    //{
        
    //    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
    //    {
    //        dependencyStatus = task.Result;
    //        if (dependencyStatus == DependencyStatus.Available)
    //        {
    //            //If they are avalible Initialize Firebase
    //            InitializeFirebase();
    //        }
    //        else
    //        {
    //            Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
    //        }
    //    });
    //}

    //private void InitializeFirebase()
    //{
    //    Debug.Log("Setting up Firebase Auth");
    //    //Set the authentication instance object
    //    auth = FirebaseAuth.DefaultInstance;

    //}
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChange;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(string email,string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
                return;
            if (task.IsFaulted)
            {
                Debug.Log(task.Exception.InnerException.Message);
                return;
            }

            if (task.IsCompletedSuccessfully)
                Debug.Log("RegisterSucess");
        });

    }
    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
                return;
            if (task.IsFaulted)
            {
                Debug.Log("Loagin"+task.Exception.InnerException.Message);
                return;
            }

            if (task.IsCompletedSuccessfully)
                Debug.Log("login");
        });
    }

    public void Logout()
    {
        auth.SignOut();
    }

    public void SaveData(bool stage1Bool)
    {
        if(user!=null)
        {
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            reference.Child(user.UserId).Child("email").SetValueAsync(user.Email).ContinueWith(task =>
            {   if (task.IsCompletedSuccessfully)
                    Debug.Log("SaveSucess");

            });
            reference.Child(user.UserId).Child("stage1").SetValueAsync(stage1Bool);


        }

    }
   
  
    public DatabaseReference GetUerImformation()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        return reference.Child(user.UserId);
    }
    void AuthStateChange(object sender,System.EventArgs eventArgs)
    {
        if(auth.CurrentUser!=user)
        {
            user = auth.CurrentUser;
            if (user != null)
                Debug.Log($"login {user.Email}");
        }

                

    }
    private void OnDestroy()
    {
        auth.StateChanged -= AuthStateChange;
    }
}
