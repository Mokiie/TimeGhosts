using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0.5f,0.5f,0.5f);
    }

    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}
