using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pickup : MonoBehaviour
{
    // Start is called before the first frame update

    
    private int healthAmount = 0;
    private float nextSpawn = 0.0f;
    private float spawnRate = 0.7f;
    private int spawnDistance = 20;

    private Health_Spawner hs;

 
    void Start()
    {
        hs = GameObject.Find("Health_Spawner").GetComponent<Health_Spawner>();
       
        Destroy(gameObject, 10.0f);
    }
    public void setHealthSpawner(Health_Spawner healthSpawner)
    {
        this.hs = healthSpawner;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Colliding w the ship
        if (coll.gameObject.name == "Ship" && hs != null)
        {
            ship ship = GameObject.Find("Ship").GetComponent<ship>();
            ship.pickUpHealth();
        }
        

        Destroy(gameObject);

    }
}
