using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] background;
    [SerializeField] Collider2D coll;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "w")
        {
            Instantiate(background[Random.Range(0,background.Length)], other.transform.position,  Quaternion.identity);
            other.GetComponentInChildren<Collider2D>().enabled = false;
        }
    }
}
