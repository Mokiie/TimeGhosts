using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float heightDif;
    Vector3 targetPosition;
    private float startHeight;
    Vector3 startPosition;
    int count;

    private void OnTriggerEnter(Collider col)
    {
        count++;
    }
    private void OnTriggerExit(Collider col)
    {
        count--;
    }

    private void Start()
    {
        count = 0;
        startHeight = door.transform.position.y;
        startPosition = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
        targetPosition = new Vector3(door.transform.position.x, startHeight + heightDif, door.transform.position.z);
    }

    private void Update()
    {
        if (count > 0)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, startPosition, moveSpeed * Time.deltaTime);
        }
    }
}
