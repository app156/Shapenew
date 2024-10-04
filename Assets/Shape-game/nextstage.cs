using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class nextstage : MonoBehaviour
{
    [SerializeField]
    FirebaseManger firebase;
        

    nexteffect nexteffect;
   
    [SerializeField] controlplayer playercontrol;

    private void Awake()
    {
       if(firebase==null)
            firebase = FindFirstObjectByType<FirebaseManger>();
    }
    // Start is called before the first frame update
    void Start()
    {
        nexteffect=GetComponent<nexteffect>();
        playercontrol = UIManger.Instance.playercontrol;
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"&& !UIManger.Instance.playerdie.Die)
        {

            UIManger.Instance.playerWin = true;

            firebase.SaveData(true);



            playercontrol.enabled = false;
            nexteffect.enabled = true;


        }

    }
    
}
