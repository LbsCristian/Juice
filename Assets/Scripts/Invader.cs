using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Build.Content;
using UnityEditor.TerrainTools;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites = new Sprite[2];
    public GameObject deathAnimation;
    public GameObject floatingPoints;
    
    

    SpriteRenderer spRend;
    int animationFrame;
    // Start is called before the first frame update

    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = animationSprites[0];
        
        
        
    }

    void Start()
    {
        //Anropar AnimateSprite med ett visst tidsintervall
        InvokeRepeating( nameof(AnimateSprite) , GameManager.Instance.timing, GameManager.Instance.timing);
    }

    //pandlar mellan olika sprited f�r att skapa en animation
    private void AnimateSprite()
    {
        animationFrame++;
        if(animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }
        spRend.sprite = animationSprites[animationFrame];
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            if (deathAnimation != null)
            {
                Instantiate(deathAnimation, transform.position, Quaternion.identity);
                Instantiate(floatingPoints, transform.position, quaternion.identity);
            }
           
            GameManager.Instance.points += ( 10 * GameManager.Instance.Combo);
            Debug.Log(GameManager.Instance.points);
            GameManager.Instance.OnInvaderKilled(this);
          
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Boundary")) //n�tt nedre kanten
        {
            GameManager.Instance.OnBoundaryReached();
        }
    }

}
