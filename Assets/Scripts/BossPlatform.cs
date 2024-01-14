using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    public float speed;
    public float height;
    float time;
    Vector3 startPosition;
    public bool follow;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        startPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!follow)
        {
            transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.PingPong(time * speed, height), startPosition.z);
        }
        else
        {
            transform.position = new Vector3(startPosition.x, target.transform.position.y, startPosition.z);
        }
    }
}
