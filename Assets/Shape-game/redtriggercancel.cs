using System.Collections.Generic;
using UnityEngine;

namespace sg
{
    public class redtriggercancel : MonoBehaviour
    {

       
        private Redtrigger redtrigger;

        private void Awake()
        {
            redtrigger = FindFirstObjectByType<Redtrigger>();
        
        }


        private void Update()
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Destroy(transform.gameObject);
                redtrigger.triggercount -= 1;


            }
        }
    }
}
