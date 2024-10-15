using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using TMPro;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public float bpm = 140;
    public float timing;

    public static GameManager Instance { get; private set; }
    [SerializeField]
    ParticleSystem part;
    private Player player;
    private Invaders invaders;
    private MysteryShip mysteryShip;
    private Bunker[] bunkers;
    float cameraSize;

    //public GameObject pointsText;
    TextMeshProUGUI textComponent;

    //Används ej just nu, men ni kan använda de senare
    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private void Awake()
    {
        cameraSize = Camera.main.orthographicSize;
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        textComponent = FindObjectOfType<TextMeshProUGUI>();
        timing = 60 / bpm;

    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        invaders = FindObjectOfType<Invaders>();
        mysteryShip = FindObjectOfType<MysteryShip>();
        bunkers = FindObjectsOfType<Bunker>();
        
        

        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return))
        {
            NewGame();
        }

        string pointsText = "Points: " + score;
        textComponent.text = pointsText;

    }

    private void NewGame()
    {

        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        invaders.enabled = true;
        Camera.main.orthographicSize = cameraSize;
        Camera.main.GetComponent<ScreenShake>().enabled = true;
        Time.timeScale = 1f;
        invaders.ResetInvaders();
        invaders.gameObject.SetActive(true);

        for (int i = 0; i < bunkers.Length; i++)
        {
            bunkers[i].ResetBunker();
        }

        Respawn();
    }

    private void Respawn()
    {
        Vector3 position = player.transform.position;
        position.x = 0f;
        player.transform.position = position;
        player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        invaders.gameObject.SetActive(false);
    }

    private void SetScore(int s)
    {
        this.score += s;
    }

    private void SetLives(int lives)
    {
       
    }

    public void OnPlayerKilled(Player player)
    {
        invaders.enabled = false;
        Camera.main.GetComponent<ScreenShake>().enabled = false; // stops the camera from going back to its normal position
        Time.timeScale *= 0.1f;
        Camera.main.transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, -10);
        StartCoroutine(Zoom());
        if (part != null)
        {
            part.transform.position = player.transform.position;
            part.Play();
        }
        
        player.gameObject.SetActive(false);
        SetScore(score=-score);

    }
    public IEnumerator Zoom()
    {
        while (Camera.main.orthographicSize > 4)
        {
            Camera.main.orthographicSize -= 1;
            yield return new WaitForSeconds(0.01f);
            
        }
        NewGame();

        
        
    }

    public void OnInvaderKilled(Invader invader)
    {
          
        
        
        invader.gameObject.SetActive(false);

        SetScore(10);
       

        if (invaders.GetInvaderCount() == 0)
        {
            NewRound();
        }
    }

    public void OnMysteryShipKilled(MysteryShip mysteryShip)
    {
        if (part != null)
        {
            part.transform.position = mysteryShip.transform.position;
            part.Play();
        }
        SetScore(100);
        mysteryShip.gameObject.SetActive(false);
        
    }

    public void OnBoundaryReached()
    {
        if (invaders.gameObject.activeSelf)
        {
            invaders.gameObject.SetActive(false);
            OnPlayerKilled(player);
        }
    }

}
