using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] GameObject[] hearts;
    [SerializeField] Text gameTimeUI;

    public void ActivateLoseScreen() 
    {
        loseScreen.SetActive(true);
    }

    public void ActivateWinnerScreen() 
    {
        winnerScreen.SetActive(true);
    }

    public void TryAgain() 
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateLives(int currentLives) 
    {
        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i >= currentLives) 
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void UpdateTime(float gameTime) 
    {
        gameTimeUI.text = "Time: " + Mathf.Floor(gameTime) + "''" ;
    }

}
