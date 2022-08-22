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
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip buttonPressedSxf;
    [SerializeField] AudioClip loseLifeSfx;

    public void ActivateLoseScreen() 
    {
        audioController.UpdateMusicVolume(0.2f);
        loseScreen.SetActive(true);

    }

    public void ActivateWinnerScreen() 
    {
        audioController.UpdateMusicVolume(0.2f);
        winnerScreen.SetActive(true);
    }

    public void TryAgain() 
    {
        audioController.PlaySfx(buttonPressedSxf);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        audioController.PlaySfx(buttonPressedSxf);
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
        audioController.PlaySfx(loseLifeSfx);
    }

    public void UpdateTime(float gameTime) 
    {
        gameTimeUI.text = "Time: " + Mathf.Floor(gameTime) + "''" ;
    }

}
