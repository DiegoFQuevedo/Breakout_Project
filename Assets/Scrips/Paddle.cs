using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5;
    [SerializeField] float xLimit = 7.6f;
    [SerializeField] float bigSizeTime = 10;
    [SerializeField] GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit) 
        {
            transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)//limite izquierda
        {
            transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
        }


    }

    public void IncreaseSize() 
    {
        if (!gameManager.ballIsOnPlay)
            return;
        Vector3 newSize = transform.localScale;
        newSize.x = 1.2f;
        transform.localScale = newSize;
        StartCoroutine(BackToOriginalSize());
    }

    IEnumerator BackToOriginalSize() 
    {
        yield return new WaitForSeconds(bigSizeTime);
        transform.localScale = new Vector3(1, 1, 1);
    }
}
