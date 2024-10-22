using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    
    public Laser laserPrefab;
    Laser laser;
    float speed = 5f;
    public ComboText comboText;

    public float beatTime;
    

    float horizontalInput;

    private void Awake()
    {
        
        GameManager.Instance.songStartTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 position = transform.position;

        position.x += speed * Time.deltaTime * horizontalInput;
        

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        transform.position = position;
        

        if (Input.GetKeyDown(KeyCode.Space) && laser == null)
        {
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            CheckBeat();
        }
        
        float elapsedTime = Time.time - GameManager.Instance.songStartTime;
        float closestBeatTime = Mathf.Round(elapsedTime / GameManager.Instance.timing) * GameManager.Instance.timing;

        beatTime = elapsedTime - closestBeatTime;
        

        if (Mathf.Abs(elapsedTime - closestBeatTime) <= GameManager.Instance.gracePeriod)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.OnPlayerKilled(this);
        }
    }

    void CheckBeat()
    {

        float elapsedTime = Time.time - GameManager.Instance.songStartTime;
        float closestBeatTime = Mathf.Round(elapsedTime / GameManager.Instance.timing) * GameManager.Instance.timing;

        if (Mathf.Abs(elapsedTime - closestBeatTime) <= GameManager.Instance.gracePeriod)
        {
            Debug.Log("Hit");
            
            
            laser.GetComponent<SpriteRenderer>().color = Color.red;
            
        }
        else
        {
            laser.GetComponent<TrailRenderer>().enabled = false;
            Debug.Log("Miss");
            GameManager.Instance.Combo = 0;
            laser.speed *= 0.5f;
        }
    }
}
