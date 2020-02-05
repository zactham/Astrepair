using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public ship sh;
   
   
    void Start()
    {
        
       

      
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        //transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1 , 0);


        //if it is out of a certain range off screen auto destry

        
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

        Destroy(gameObject);

    }
}
