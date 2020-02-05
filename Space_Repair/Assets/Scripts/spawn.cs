using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private ship ship;
    public alienControl alien;
    public alienProjectile projectile;
    private int spawnWidth = 3;
    private float scaler = 2.0f;
    private float nextActionTime = 0.0f;
    public float period = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ship = GameObject.Find("Ship");
        this.ship = ship.GetComponent<ship>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;

            alienControl newAlien = Instantiate(alien, getRandomVector3InZ0(), Quaternion.identity);
            newAlien.projectile = this.projectile;
        }
    }

    Vector3 getRandomVector3InZ0()
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
