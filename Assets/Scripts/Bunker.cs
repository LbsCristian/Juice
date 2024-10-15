using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bunker : MonoBehaviour
{
    int nrOfHits = 0;
    SpriteRenderer spRend;
    Color oldColor;
    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
        oldColor = spRend.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {

            //�ndrar f�rgen beroende p� antal tr�ffar.
            nrOfHits++;
            

            Color newColor = new Color(oldColor.r +(nrOfHits*0.2f), oldColor.g + (nrOfHits * 0.2f), oldColor.b + (nrOfHits * 0.2f));
            
            spRend.color = newColor;
            
            if (nrOfHits == 4)
            {
                gameObject.SetActive(false);
            }
            
        }
    }

    public void ResetBunker()
    {
        spRend.color = oldColor;
        gameObject.SetActive(true);
        nrOfHits = 0;
    }
}
