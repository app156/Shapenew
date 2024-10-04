using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ppvignee : MonoBehaviour
{
    [SerializeField] PostProcessVolume pp;
    
    Vignette vi;
    // Start is called before the first frame update
    void Start()
    {
        pp.profile.TryGetSettings(out vi);
    }

    // Update is called once per frame
    void Update()
    {
        vi.intensity.value += Mathf.Lerp(0, 1.2f, 0.004f);
        if (vi.intensity.value > 1.2f) vi.intensity.value = 1.2f;
        transform.localScale += new Vector3(Mathf.Lerp(0,-1,0.5f), Mathf.Lerp(0, -1, 0.5f),0) * 2 * Time.deltaTime;
        if (transform.localScale.x < 0.1|| transform.localScale.y < 0.1)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }
       
    }
}
