using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Asteroid asteroid;
    public ship sh;
    // for making an array of asteroid objects to reuse instead of destroying.
    private static int arraySize = 20;
    private Asteroid[] asteroids = new Asteroid[arraySize];
    private bool didFillArray = false;
    private int currentAsteroidIndex = 0;

    // spawn rate variables
    float nextSpawn = 0.0f;
    public float spawnRate = 0.2f;

    public float minScaler = 0.05f;
    public float maxScaler = 0.35f;
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
            //Spawns in the asteroid
            if (!didFillArray)
            {
                asteroids[currentAsteroidIndex] = createRandomAsteroid();
                currentAsteroidIndex++;
            } else
            {
                //if (asteroids[currentAsteroidIndex] != null)
                //{
                asteroids[currentAsteroidIndex].transform.position = getRandomVector3InZ0();
                setAstScaler(asteroids[currentAsteroidIndex]);
                asteroids[currentAsteroidIndex].makeSureAstIsVisible();
                asteroids[currentAsteroidIndex].setDirectionOfShipFromCurrentPos(sh);
                currentAsteroidIndex++;
                //}
            }
            if (currentAsteroidIndex == arraySize)
            {
                currentAsteroidIndex = 0;
                didFillArray = true;
            }
        } 
    }
    public Asteroid createRandomAsteroid()
    {
        Asteroid newAst = Instantiate(asteroid, getRandomVector3InZ0(), Quaternion.identity);
        setAstScaler(newAst);
        newAst.setDirectionOfShipFromCurrentPos(sh);
        newAst.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
        return newAst;
    }
    private void setAstScaler(Asteroid ast)
    {
        ast.scaler = getRandomScaler();
        ast.transform.localScale = new Vector3(ast.scaler, ast.scaler, ast.scaler);
        ast.health *= ast.scaler;
    }
    private float getRandomScaler()
    {
 
        return Random.Range(minScaler, maxScaler);
    }
    public Vector3 getRandomVector3InZ0()
    {
        Vector2 v3Pos;
        //Needs to be based on the ship's location
        int rnd = Random.Range(0, 2);
        if (rnd > 0)
        {
            v3Pos = getRandom2();
        }
        else
        {
            v3Pos = new Vector2(getRandom(), getRandom());
        }
        //
        Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(v3Pos);
        spawnLoc.z = 0;
        return spawnLoc;

    }
    float getRandom()
    {
        int rnd = Random.Range(0, 2);
        if (rnd > 0)
        {
            // return random that is off the left side or top (depending if being used for x or y val)
            return Random.Range(-2.0f, -0.5f);
        }
        // return random that is off the right side or top (depending if being used for x or y val)
        return Random.Range(1.5f, 3.0f);

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
