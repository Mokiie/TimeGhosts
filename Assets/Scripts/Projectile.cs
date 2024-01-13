using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float lifetime = 20;
   // private float timer = 0;

    private void Awake()
    {
        //timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer >= lifetime) 
         // Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}
