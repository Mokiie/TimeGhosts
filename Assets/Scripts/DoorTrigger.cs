using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float distance;
    [SerializeField] bool x;
    [SerializeField] bool y;
    [SerializeField] bool z;
    Vector3 targetPosition;
    private float startHeight;
    Vector3 startPosition;
    public int otherColliders;
    Collider[] colliders = new Collider[20];
    bool isPressed;
   

    private void Start()
    {

        if (x)
        {
            startHeight = door.transform.position.x;
            startPosition = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
            targetPosition = new Vector3(startHeight + distance, door.transform.position.y, door.transform.position.z);
        }
        else if(y)
        {
            startHeight = door.transform.position.y;
            startPosition = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
            targetPosition = new Vector3(door.transform.position.x, startHeight + distance, door.transform.position.z);
        }else if (z)
        {
            startHeight = door.transform.position.y;
            startPosition = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
            targetPosition = new Vector3(door.transform.position.x, door.transform.position.y, startHeight + distance);
        }
        
    }

    private void Update()
    {
        if (isPressed)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, startPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        int numColliders = Physics.OverlapBoxNonAlloc(transform.position, transform.localScale, colliders, Quaternion.identity);
        //Debug.Log(numColliders);
        isPressed =  (numColliders> otherColliders ? true : false);
    }

}
