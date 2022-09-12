using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody2d;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    [SerializeField] float ballSpeed = 5;
   // GameManager gameManager;
    Transform paddle;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip bounceSfx;

    bool superBall;
    [SerializeField] float superBallTime = 10f;

    [SerializeField] float yMinSpeed = 2;
    [SerializeField] TrailRenderer trailRenderer;

    public bool SuperBall 
    {
        get => superBall;
        set { 
            superBall = value;
            if(superBall)
            StartCoroutine(ResetSuperBall());
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody2d = GetComponent<Rigidbody2D>();
        //rigidBody2d.velocity = Vector2.up * ballSpeed;
        GameManager.Instance = FindObjectOfType<GameManager>();
        paddle = transform.parent;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.ballIsOnPlay) 
        {
            rigidBody2d.velocity = Vector2.up * ballSpeed;
            transform.parent = null;
            GameManager.Instance.ballIsOnPlay = true;
            if (!GameManager.Instance.GameStarted) 
            {
                GameManager.Instance.GameStarted = true;
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
        if (collision.transform.CompareTag("Brick") && superBall) 
        {
            rigidBody2d.velocity = currentVelocity;
            return;
        }

        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        if (Mathf.Abs(moveDirection.y) < yMinSpeed) 
        {
            moveDirection.y = yMinSpeed * Mathf.Sign(moveDirection.y);
        }
        rigidBody2d.velocity = moveDirection;
        audioController.PlaySfx(bounceSfx);

        if (collision.transform.CompareTag("BottomLimit")) 
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PlayerLives--;

                if (GameManager.Instance.PlayerLives > 0) 
                {
                    rigidBody2d.velocity = Vector2.zero;//detenemos la velociad
                 // transform.parent = paddle;
                    transform.SetParent(paddle);//la hacemos hija del paddle
                    transform.localPosition = new Vector2(0, 0.62f);//asignamos posicion 
                    GameManager.Instance.ballIsOnPlay = false;

                }
                
            }


        }

    }

    IEnumerator ResetSuperBall() 
    {
        trailRenderer.enabled = true;
        yield return new WaitForSeconds(superBallTime);
        trailRenderer.enabled = false;
        GameManager.Instance.powerUpIsActive = false;
        superBall = false;
    }
}
