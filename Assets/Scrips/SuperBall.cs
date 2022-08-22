using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBall : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            Ball ball = FindObjectOfType<Ball>();
            if (ball != null) 
            {
                ball.SuperBall = true;
            }

            Destroy(gameObject);
        }
    }
}