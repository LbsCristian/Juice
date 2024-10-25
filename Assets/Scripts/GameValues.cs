using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-1)]
public class GameValues : MonoBehaviour
{

    public float gracePeriod2;

    public int currentHighScore;
    public static GameValues Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
       
        if (GameManager.Instance != null)
        {
           
        }
    }
    private void Start()
    {
        currentHighScore = GameManager.Instance.highScore;
        print(currentHighScore);
    }
    


}
