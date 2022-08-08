using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody2d;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    [SerializeField] float ballSpeed = 5;
    GameManager gameManager;
    Transform paddle;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip bounceSfx;

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody2d = GetComponent<Rigidbody2D>();
        //rigidBody2d.velocity = Vector2.up * ballSpeed;
        gameManager = FindObjectOfType<GameManager>();
        paddle = transform.parent;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameManager.ballIsOnPlay) 
        {
            rigidBody2d.velocity = Vector2.up * ballSpeed;
            transform.parent = null;
            gameManager.ballIsOnPlay = true;
            if (!gameManager.GameStarted) 
            {
                gameManager.GameStarted = true;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentVelocity = rigidBody2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidBody2d.velocity = moveDirection;
        audioController.PlaySfx(bounceSfx);

        if (collision.transform.CompareTag("BottomLimit")) 
        {
            if (gameManager != null)
            {
                gameManager.PlayerLives--;

                if (gameManager.PlayerLives > 0) 
                {
                    rigidBody2d.velocity = Vector2.zero;//detenemos la velociad
                 // transform.parent = paddle;
                    transform.SetParent(paddle);//la hacemos hija del paddle
                    transform.localPosition = new Vector2(0, 0.62f);//asignamos posicion 
                    gameManager.ballIsOnPlay = false;

                }
                
            }


        }

    }
}
