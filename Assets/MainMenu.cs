using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMainMenu;
    public GameObject optionsMenu;



    private void Awake()
    {
        GameValues.Instance.gracePeriod2 = 0.15f;
    }

    public void startGame()
    {
        SceneManager.LoadScene("Oscar");
    }

    public void easy()
    {
        GameValues.Instance.gracePeriod2 = 0.2f;
    }

    public void medium()
    {
        GameValues.Instance.gracePeriod2 = 0.15f;
    }

    public void hard()
    {
        GameValues.Instance.gracePeriod2 = 0.11f;
    }

    public void back()
    {
        optionsMenu.SetActive(false);
        mainMainMenu.SetActive(true);
    }

    public void options()
    {
        optionsMenu.SetActive(true);
        mainMainMenu.SetActive(false);
    }

}
