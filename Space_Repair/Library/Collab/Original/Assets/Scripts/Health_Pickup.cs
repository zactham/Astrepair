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
        if (coll.gameObject.name == "Ship")
        {
            //Play Sound

            //Edit the ships health
            sh.health += 50;

            //Change bag UI
        }
       

        Destroy(gameObject);

    }
}
