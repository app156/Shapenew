using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    GameObject att;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        att = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left*5*Time.deltaTime);
        
    }
}
