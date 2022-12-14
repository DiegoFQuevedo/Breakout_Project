using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject, delay);
    }

    public void DestroyFromEvent() 
    {
        Destroy(gameObject);
    }
}
