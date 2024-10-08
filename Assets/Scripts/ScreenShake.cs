using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Camera cam;
    public float shakeTime;
    public float shakeIntensity;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shakeTime > 0)
        {
            cam.transform.localPosition = Random.insideUnitCircle * shakeIntensity;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10); 
            shakeTime -= Time.deltaTime;
        }
        else
        {
            cam.transform.position = new Vector3(0, 0, -10);
            
        }
        
        
        
    }
   
}
