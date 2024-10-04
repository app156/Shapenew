using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        InvokeRepeating("colo", 0, 2.2f);
    }

    // Update is called once per frame
    

    void colo()
    {
      
        render.color = new Color(Random.value, Random.value, Random.value);
    }

}
