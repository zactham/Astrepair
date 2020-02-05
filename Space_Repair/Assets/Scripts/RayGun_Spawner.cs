using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun_Spawner : MonoBehaviour
{

    private int gunAmount = 0;
    private int gunCap = 40;
    public ship sh;
    public Shooting_Pickup sp;

    private float nextSpawn = 0.0f;
    private float spawnRate = 0.7f;

    private float randX;
    private float randY;

    private int spawnDistance = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            //Spawn 5 ray guns randomly around the map

            var shipX = sh.transform.position.x;
            var shipY = sh.transform.position.y;

            Shooting_Pickup rpN = new Shooting_Pickup();


            //TOP LEFT
            if (gunAmount == 0)
            {
                 randX = Random.Range(sh.transform.position.x - spawnDistance, sh.transform.position.x);
                 randY = Random.Range(sh.transform.position.y, sh.transform.position.y + spawnDistance);

               
            }
            else if (gunAmount == 10)
            {
                 randX = Random.Range(sh.transform.position.x, sh.transform.position.x + spawnDistance);
                 randY = Random.Range(sh.transform.position.y, sh.transform.position.y + spawnDistance);
                
            }

            else if (gunAmount == 20)
            {
                 randX = Random.Range(sh.transform.position.x - spawnDistance, sh.transform.position.x);
                 randY = Random.Range(sh.transform.position.y - spawnDistance, sh.transform.position.y);
                
            }

            else if (gunAmount == 30)
            {
                 randX = Random.Range(sh.transform.position.x, sh.transform.position.x + spawnDistance);
                 randY = Random.Range(sh.transform.position.y - spawnDistance, sh.transform.position.y);
                
                gunAmount = 9;

            }
            rpN = Instantiate(sp, new Vector3(randX, randY, 0), Quaternion.identity);
            rpN.rgs = this;
            gunAmount++;
        }
    }
}
