using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landfirst : MonoBehaviour
{
    CinemachineCollisionImpulseSource im;
    // Start is called before the first frame update
    void Start()
    {
        im=GetComponent<CinemachineCollisionImpulseSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "land") Invoke("impuse", 0.2f);
    }

    void impuse()
    {
        im.enabled = false;
    }
}
