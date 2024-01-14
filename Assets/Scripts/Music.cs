using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject music1;
    public GameObject music2;
    public GameObject boss;
    public GameObject wizants;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Music2();

            boss.SetActive(true);
            wizants.SetActive(false);
        }
    }

    public void Music1()
    {
        music1.SetActive(true);
        music2.SetActive(false);
    }

    public void Music2()
    {
        music1.SetActive(false);
        music2.SetActive(true);
    }

}
