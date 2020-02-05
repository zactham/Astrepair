using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public ship sh;
    public ship sh;
    public float X = 0;
    public float Y = 0;
    public Vector2 relativeMovement = new Vector2(0, 0);
    private bool motionSet = false;
    public float speed = 5f;
    private int scaleDownSpeed = 10;

    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        var pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);

        relativeMovement = (pos - new Vector2(transform.position.x, transform.position.y)).normalized / scaleDownSpeed;
    
        //relativeMovement.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // update the relative motion to where the ship is facing (which is based on the mouse position)
        motionSet = true;

        relativeMovement += relativeMovement / scaleDownSpeed;
        transform.position += new Vector3(relativeMovement.x, relativeMovement.y, 0);
        Destroy(gameObject, 0.8f);
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.name == "Asteroids(Clone)")
        {
            //Increase score
           Score.scoreValue += 10;

            Destroy(gameObject);
        }

        //Debug.Log($"hit: {collision.gameObject.name}");
        //Destroy(gameObject);
    }
}
