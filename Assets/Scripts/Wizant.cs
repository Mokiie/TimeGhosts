using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizant : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public float fireRate;
    float time;
    public float angle1;
    public float angle2;
    private Vector3 startAngle; 
    private Vector3 endAngle;
    public float rotationSpeed;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    int index;
    //float spriteTimer;

    // Start is called before the first frame update
    void Start()
    {
        startAngle = new Vector3(0f, angle1, 0f);
        endAngle = new Vector3(0f, angle2, 0f);
        //spriteTimer = 0;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time >= 1 / fireRate)
        {
            Rigidbody clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
            clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * 10);
            time = 0;

            if(spriteRenderer != null)
            {
                index++;
                if (index >= 4) index = 0;
                spriteRenderer.sprite = sprites[index];
            }



        }

        Spawnpoint.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(startAngle), Quaternion.Euler(endAngle), 0.5f * (1f + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.rotationSpeed)));
        //.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 60, 90),0 );
        
        
        //spriteTimer += Time.deltaTime;


    }
}
