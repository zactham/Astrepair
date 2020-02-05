using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spawner : MonoBehaviour
{
    public ship sh;
    public Projectile bullet;

    float nextSpawn = 0.0f;
    public float spawnRate = 0.0f;
    public float hitPower = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fire Projectile
        if (Input.GetKeyDown("space") && Time.time > nextSpawn && sh.getCanShoot())
        {
            nextSpawn = Time.time + spawnRate;

            //Vector3 mousePosition = Input.mousePosition;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            //Vector2 direction = new Vector2(
            //    mousePosition.x - transform.position.x,
            //    mousePosition.y - transform.position.y
            //    );

            //transform.up = direction;

            //Spawn a projectile
            Instantiate(bullet, new Vector3(sh.transform.position.x, sh.transform.position.y, 0), Quaternion.identity);

        }
    }
}
