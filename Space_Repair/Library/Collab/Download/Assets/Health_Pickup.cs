using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pickup : MonoBehaviour
{
    // Start is called before the first frame update

    public ship sh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Colliding w the ship
        //if (collision.gameObject.name == "Ship")
        {
            //Play Sound
            //Change the asteroid images
            //Destroy the asteroid

            //Edit the ships health
        }
        sh.health -= 5;

        Destroy(gameObject, 0.5f);

    }
}
