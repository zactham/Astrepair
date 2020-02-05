using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Pickup : MonoBehaviour
{

    public ship sh;
    // Start is called before the first frame update
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

            //Edit the ships speed
            sh.moveSpeed += 3;

            //Change bag UI

        }


        Destroy(gameObject);

    }
}
