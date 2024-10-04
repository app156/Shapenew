using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;



public class die : MonoBehaviour
{

    controlplayer control;
    
    [SerializeField] CinemachineVirtualCamera cine;
    [SerializeField] ppvignee ppcontr;
    [SerializeField] AudioSource stabvoice;

   
    
    [SerializeField] public bool Die = false;
    // Start is called before the first frame update


    // Update is called once per frame

    void Start()
    {
        Time.timeScale = 1;
        control = UIManger.Instance.playercontrol; 
        

        
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy" && !UIManger.Instance.playerWin)
        {
            stabvoice.Play();
           
            Invoke("VVOICE", 0.1f);
            Dead();
            Invoke("Stopcam", 0.2f);
            ppcontr.enabled = true;
            Die = true;


        }
        if (other.name == "down" && !UIManger.Instance.playerWin)
        {
            Dead();
            Stopcam();
            ppcontr.enabled = true;
            Die = true;
        }
    }



   
    void Stopcam()
    {
        cine.enabled = false;
    }
    void Dead()
    {
        control.enabled = false;
        Invoke("bottomlate", 1);

    }

   
    void VVOICE()
    { stabvoice.enabled = false; }
}
