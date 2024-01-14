using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public float fireRate;
    float time;
    //public float angle1;
    //public float angle2;
    //private Vector3 startAngle;
    //private Vector3 endAngle;
    public float rotationSpeed;
    public float burstLength;
    public float burstDelay;
    bool firing;
    float fireTime;
    public float spread;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        //startAngle = new Vector3(0f, angle1, angle1);
        //endAngle = new Vector3(0f, angle2, angle2);
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        fireTime += Time.deltaTime;

        if(time > burstDelay && time < burstDelay + burstLength)
        {
            firing = true;
            if(spriteRenderer!=null)
                spriteRenderer.sprite = sprites[1];
        }
        else if (time >= burstDelay + burstLength)
        {
            time = 0;
            firing = false;
            if (spriteRenderer != null)
                spriteRenderer.sprite = sprites[0];
        }

        if (firing)
        {
            if (fireTime >= 1 / fireRate)
            {
                Rigidbody clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
                clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * 10);
                fireTime = 0;
            }
        }

        Spawnpoint.transform.eulerAngles = new Vector3(Spawnpoint.transform.rotation.x, Mathf.Cos((Time.realtimeSinceStartup * rotationSpeed) % 360)*spread, Mathf.Sin((Time.realtimeSinceStartup * rotationSpeed) % 360)*spread);

        //Spawnpoint.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(startAngle), Quaternion.Euler(endAngle), 0.5f * (1f + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.rotationSpeed)));
        //.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 60, 90),0 );


        //spriteTimer += Time.deltaTime;


    }
}
