using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public Color[] colors;
    Camera cam;
    public float bpm = 140;
    float timing;
   

    private void Awake()
    {
        timing = 60 / bpm;
        cam = GetComponent<Camera>();
        InvokeRepeating("ColorChange", 0f, timing);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       

    }

    void ColorChange()
    {

        cam.backgroundColor = colors[Random.Range(0, colors.Length)];
    }

    
}
