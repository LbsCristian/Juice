using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatIndicator : MonoBehaviour
{
    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Abs(FindAnyObjectByType<Player>().beatTime)*multiplier;
        transform.position = position;
    }
}
