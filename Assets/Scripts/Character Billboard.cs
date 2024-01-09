using UnityEngine;

public class CharacterBillboard : MonoBehaviour
{

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 targetPosition = transform.InverseTransformDirection(new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z));
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z); ;
        transform.LookAt(targetPosition);
    }
}
