using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Spawner: MonoBehaviour
{
    // Start is called before the first frame update

    public ship sh;
    private int healthAmount = 0;
    private float nextSpawn = 0.0f;
    private float spawnRate = 0.7f;
    private int spawnDistance = 20;
    private float randX;
    private float randY;

    public Health_Pickup hp;
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


            Health_Pickup hpN;

            //TOP LEFT
            if (healthAmount == 0)
            {
                randX = Random.Range(sh.transform.position.x - spawnDistance, sh.transform.position.x);
                randY = Random.Range(sh.transform.position.y, sh.transform.position.y + spawnDistance);

            }
            else if (healthAmount == 10)
            {
                 randX = Random.Range(sh.transform.position.x, sh.transform.position.x + spawnDistance);
                 randY = Random.Range(sh.transform.position.y, sh.transform.position.y + spawnDistance);
               
            }

            else if (healthAmount == 20)
            {
                 randX = Random.Range(sh.transform.position.x - spawnDistance, sh.transform.position.x);
                 randY = Random.Range(sh.transform.position.y - spawnDistance, sh.transform.position.y);
               
            }

            else if (healthAmount == 30)
            {
                 randX = Random.Range(sh.transform.position.x, sh.transform.position.x + spawnDistance);
                 randY = Random.Range(sh.transform.position.y - spawnDistance, sh.transform.position.y);
               
                healthAmount = 9;

            }
            hpN = Instantiate(hp, new Vector3(randX, randY, 0), Quaternion.identity);
            hpN.setHealthSpawner(this);
            healthAmount++;
        }
    }
}
