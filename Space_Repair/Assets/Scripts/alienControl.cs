using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienControl : MonoBehaviour
{
    // Start is called before the first frame update
    private ship ship;
    public alienProjectile projectile;
    private float nextActionTime = 0.0f;
    private float period = 3.0f;
    void Start()
    {
        GameObject ship = GameObject.Find("Ship");
        this.ship = ship.GetComponent<ship>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtShip();
        //Debug.Log($"time: {Time.time} nextActoinTime: {nextActionTime}");
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            shootAtShip();
        }

    }

    public void setProjectile(alienProjectile projectile)
    {
        this.projectile = projectile;
    }
    public void shootAtShip()
    {
        //Debug.Log(projectile);
        if (projectile != null)
        {
            alienProjectile newProj = Instantiate(projectile, transform.position, Quaternion.identity);
            newProj.setDirectionOfShipFromCurrentPos(ship);
        }
    }
    void LookAtShip()
    {
        Vector3 shipPost = ship.transform.position;
        shipPost = Camera.main.ScreenToWorldPoint(shipPost);

        Vector2 direction = new Vector2(
            shipPost.x - transform.position.x,
            shipPost.y - transform.position.y
            );

        transform.up = direction;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.name == "Ship")
        {
            //Increase score

            ship.changeHealthBy(-0.05f);
        }

        //Debug.Log($"hit: {collision.gameObject.name}");
        Destroy(gameObject);
    }
}
