using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatIndicator : MonoBehaviour
{
    public int multiplier;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        
        position.x = Mathf.Abs(player.beatTime) * multiplier;
        
        
        transform.position = position;
    }
}
