using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float speed = 10;
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            Paddle paddle = FindObjectOfType<Paddle>();
            if (paddle != null) 
            {
                paddle.BulletsActive = true;
            }
        
        }
    }
}