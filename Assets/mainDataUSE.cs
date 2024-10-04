using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class mainDataUSE : MonoBehaviour
{
    public FirebaseManger Firebase;

    public TMP_InputField inputEmail, inputpassport;
    public TMP_Text UsernameFrom;
    public GameObject titlegameObject,loginobject;

    public GameObject stage2;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Firebase == null)
            Firebase = FindFirstObjectByType<FirebaseManger>();

    }

    void Start()
    {
        Firebase.auth.StateChanged += AuthStateChange;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Register()
    {
        Firebase.Register(inputEmail.text, inputpassport.text);
    }
    public void Login()
    {
        Firebase.Login(inputEmail.text, inputpassport.text);
    }
    void AuthStateChange(object sender, System.EventArgs eventArgs)
    {
        if (Firebase.auth.CurrentUser == null)

        {
            loginobject.gameObject.SetActive(true);
            titlegameObject.gameObject.SetActive(false);
            UsernameFrom.text = "";
        }
        else
        {
            loginobject.gameObject.SetActive(false);
            StartCoroutine(LoadData());
            UsernameFrom.text = $"Email:{Firebase.user.Email}";
            titlegameObject.gameObject.SetActive(true);
            
        }
    }

    IEnumerator LoadData()
    {
        var task = Firebase.GetUerImformation().Child("stage1").GetValueAsync();

        yield return new WaitUntil(() => task.IsCompletedSuccessfully);

        stage2.SetActive((bool)task.Result.Value);



    }
    private void OnDestroy()
    {
        Firebase.auth.StateChanged -= AuthStateChange;
    }

}
