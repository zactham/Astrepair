using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Asteroid asteroid;
    public ship sh;


    float minX = 0f;
    float maxX = 0f;
    float minY = 0f;
    float maxY = 0f;

    float randomX;
    float randomY;

    float nextSpawn = 0.0f;
   public float spawnRate = 0.0f;

    //Minium distance that the asteroids should be spawned in at
    float distanceToCorner = 0f;
       
    void Start()
    {
        //Creates the asteroid
        asteroid.sh = sh;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 v3Pos;
            //Needs to be based on the ship's location
            int rnd = Random.Range(0, 2);
            if (rnd > 0)
            {
                v3Pos = getRandom2();
            } else
            {
                v3Pos = new Vector2(getRandom(), getRandom());
            }

            //Spawns in the asteroid
            Instantiate(asteroid, Camera.main.ViewportToWorldPoint(v3Pos), Quaternion.identity);
           
        } 
    }
    float getRandom()
    {
        int rnd = Random.Range(0, 2);
        if (rnd > 0)
        {
            return Random.Range(-1.0f, 0.0f);
        }
        return Random.Range(1.0f, 2.0f);

    }
    Vector2 getRandom2()
    {
        int rnd = Random.Range(0, 2);

        if (rnd > 0)
        {
            return new Vector2(Random.Range(0.0f, 1.0f), getRandom());
        }
        return new Vector2(getRandom(), Random.Range(0.0f, 1.0f));
    }
}
