using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletLife;
    public float rotation;
    public float speed;
    private Vector3 spawnPoint;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= bulletLife)
            Destroy(gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }
    private Vector3 Movement(float timer)
    {
        return new Vector3(timer*speed*transform.position.x + spawnPoint.x, spawnPoint.y ,timer * speed * transform.position.z + spawnPoint.z);
    }
}
