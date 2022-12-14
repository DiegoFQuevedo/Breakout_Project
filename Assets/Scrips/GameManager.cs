using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    int bricksOnLevel;
    [SerializeField] int playerLives = 3;
    public bool ballIsOnPlay;
    float gameTime;
    bool gameStarted;
    [SerializeField] UIController uiController;
    public bool powerUpOnScene;
    public bool powerUpIsActive;

    //public GameObject ball;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    public int BricksOnLevel 
    {
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            if (bricksOnLevel == 0) 
            {
                //Destroy(ball);
                Destroy(GameObject.Find("Ball"));
                uiController.ActivateWinnerScreen();
                gameTime = Time.time - gameTime;
                uiController.UpdateTime(gameTime);
            }
        
        }
    
    }

    public int PlayerLives {
        get => playerLives;
        set {
            playerLives = value;
            uiController.UpdateLives(playerLives); 
            if (playerLives == 0)
            {
                Destroy(GameObject.Find("Ball"));
                uiController.ActivateLoseScreen();

            }

        }
    }

    public bool GameStarted 
    {
        get => gameStarted;
        set {
            gameStarted = value;
            gameTime = Time.time;
        }
    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}
