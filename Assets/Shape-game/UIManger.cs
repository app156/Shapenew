using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    [SerializeField] public GameObject UI111;
    [SerializeField] private GameObject popup;
    [SerializeField] public die playerdie;
    [SerializeField] public Rigidbody2D playerRig;
    [SerializeField] private GameObject AllUI;
    [SerializeField] public TextMeshProUGUI CountText;
    [SerializeField] public GameObject Getview;
    [SerializeField] public bool playerWin = false;
    [SerializeField] public GameObject nextButton;
    [SerializeField] public controlplayer playercontrol;
    [SerializeField] public int currentsceneindex;
    private void Awake()
    {


        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);


    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        playerdie = FindFirstObjectByType<die>();
        playerRig = playerdie.GetComponent<Rigidbody2D>();

        if (!playerWin)
            nextButton.SetActive(false);
    }

    private void LateUpdate()
    {
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;

        if (currentsceneindex == 0)
            AllUI.SetActive(false);


        if (currentsceneindex != 0)
        {
            AllUI.SetActive(true);
            if (!playerdie.Die || playerdie == null)
            {
                UI111.gameObject.SetActive(true);
                popup.gameObject.SetActive(false);
            }
            else if (playerdie.Die)
            {
                UI111.gameObject.SetActive(false);
                Getview.gameObject.SetActive(false);
                StartCoroutine(DieUIchang());
            }
            else if (playerWin)
            {
                UI111.gameObject.SetActive(false);
            }

        }




    }
    private IEnumerator DieUIchang()
    {

        yield return new WaitForSeconds(1);

        popup.gameObject.SetActive(true);



    }
    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playercontrol.enabled = true;
    }
    public void NextSceneSwitch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playerWin = false;
        playercontrol.enabled = true;


    }

    public void setExit()
    {
        Application.Quit();
    }
    public void stopaction()
    {
        Time.timeScale = 0;
    }
    public void action()
    {
        Time.timeScale = 1;
    }



}
