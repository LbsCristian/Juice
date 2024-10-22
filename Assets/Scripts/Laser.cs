using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Projectile
{
    ComboText comboText;
    ScreenShake shake;    
    private void Awake()
    {
        shake = Camera.main.GetComponent<ScreenShake>();
        direction = Vector3.up;
        speed = 75f;
        comboText = FindAnyObjectByType<ComboText>();
        
    }
    private void Start()
    {
        if (speed == 75f)
        {
            GameManager.Instance.beatHitEffect.Play();

        }
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    void CheckCollision(Collider2D collision)
    {
        Bunker bunker = collision.gameObject.GetComponent<Bunker>();
        Invader invader = collision.gameObject.GetComponent<Invader>();
        MysteryShip mysteryShip = collision.gameObject.GetComponent<MysteryShip>();

        if (invader != null&&speed==75) //Om man träffar en invader så skakar kameran.
        {
            shake.shakeTime = 0.1f;
            shake.shakeIntensity = 1f;
            GameManager.Instance.Combo++;
            comboText.GetComponent<Animation>().Rewind();
            comboText.GetComponent<Animation>().Play();
        }
        if (mysteryShip != null&&speed==75)
        {
            shake.shakeTime = 0.3f;
            shake.shakeIntensity = 1.3f;
        }
        if (bunker == null) //Om det inte är en bunker vi träffat så ska skottet försvinna.
        {
            Destroy(gameObject);
           
        }

    }
}
