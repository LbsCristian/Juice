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
    

    GameManager gm;
    float horizontalInput;

    private void Awake()
    {
        gm = FindAnyObjectByType<GameManager>();
        gm.songStartTime = Time.time;
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

        float elapsedTime = Time.time - gm.songStartTime;
        float closestBeatTime = Mathf.Round(elapsedTime / gm.timing) * gm.timing;

        if (Mathf.Abs(elapsedTime - closestBeatTime) <= gm.gracePeriod)
        {
            Debug.Log("Hit");
            gm.Combo++;
            comboText.GetComponent<Animation>().Rewind();
            comboText.GetComponent<Animation>().Play();
            laser.GetComponent<SpriteRenderer>().color = Color.red;
            
        }
        else
        {
            laser.GetComponent<TrailRenderer>().enabled = false;
            Debug.Log("Miss");
            gm.Combo = 0;
            laser.speed *= 0.5f;
        }
    }
}
