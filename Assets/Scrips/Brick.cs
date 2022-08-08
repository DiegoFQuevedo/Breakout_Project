using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    //GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] GameObject explosionPrefab;
    private void Start()
    {
       /* gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj != null) {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            if (gameManager != null) {
                gameManager.bricksOnLevel++;
            }
        }*/
       
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null) 
        {
            gameManager.BricksOnLevel++;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameManager != null)
        {
            gameManager.BricksOnLevel--;
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
