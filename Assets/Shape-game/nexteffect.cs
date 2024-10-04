using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class nexteffect : MonoBehaviour
{
    
    [SerializeField] PostProcessVolume pp;
    [SerializeField] private die player;
    [SerializeField] private SpriteRenderer playerpicture;
    
    [SerializeField] Transform playtra;
  


    Bloom bloom;
    // Start is called before the first frame update
    void Start()
    {
        pp.profile.TryGetSettings(out bloom);
        player = UIManger.Instance.playerdie;
        playerpicture = player.GetComponent<SpriteRenderer>();
        playtra = player.GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        bloom.intensity.value += Mathf.Lerp(0, 130, 0.005f);
        if (bloom.intensity.value > 120) bloom.intensity.value = 130;
        Vector3 vv =new Vector3 (1,1,1);
        playtra.position =new Vector2(Mathf.Lerp(playtra.position.x,transform.position.x, 0.09f), Mathf.Lerp(playtra.position.y, transform.position.y, 0.05f)) ;

        Invoke("lightoff", 0.8f);
       
        
        
        


    }
    
    void lightoff()
    {
        bloom.intensity.value -= Mathf.Lerp(1, 130, 0.005f);
        if (bloom.intensity.value == 1) bloom.intensity.value = 12;

        if (bloom.intensity.value > 11) 
        {
            

            playerpicture.enabled = false;

            
                }
        ;

        if (playerpicture.enabled == false) Invoke("turnoff", 0.5f);
    }
      
    void turnoff()
    {
       UIManger.Instance.nextButton.SetActive(true);
    }
}
