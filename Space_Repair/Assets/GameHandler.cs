using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    public ship ship;
    float nextSpawn = 0.0f;
    private float spawnRate = 0.0001f;
    [SerializeField] private HealthBar healthBar;
    

    // Start is called before the first frame update
    void Update () {
        Debug.Log($"Ships current health: {ship.health}");
        float health = ship.health;
        //FunctionPeriodic.Create(() => {
        //    if (health > .01f)
        //    {
        //        ship.changeHealthBy(-.0001f);
        //        healthBar.SetSize(health);
        //        if (health < .3f)
        //        {
        //            healthBar.SetColor(Color.red);
        //        } else
        //        {
        //            healthBar.SetColor(Color.green);
        //        }

        //        //}
        //    }
        //}, .3f);
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            if (health > .01f)
            {
                ship.changeHealthBy(-.001f);
                healthBar.SetSize(health);
                if (health < .3f)
                {
                    healthBar.SetColor(Color.red);
                }
                else
                {
                    healthBar.SetColor(Color.green);
                }

                //}
            }
        }

    }
    private void Start()
    {
        ship = GameObject.Find("Ship").GetComponent<ship>();
 

    }

   
}
