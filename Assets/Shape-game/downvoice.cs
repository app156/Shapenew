using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downvoice : MonoBehaviour
{
    [SerializeField] AudioSource downvoicee;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "land") 
        {
            downvoicee.Play();

            Invoke("Down", 0.2f);
        }
    }
    private void Down()
    {
        downvoicee.enabled = false;
    }
}
