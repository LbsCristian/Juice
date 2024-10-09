using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public Color[] colors;
    Camera cam;
   

    private void Awake()
    {
        cam = GetComponent<Camera>();
        InvokeRepeating("ColorChange", 0f, 0.43f);
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
