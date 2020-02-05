using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public ship sh;
    public Vector3 initialDirectionOfShip;
    public bool directionHasBeenSet = false;
    public Projectile_Spawner projSpawner;
    public int speedScaler = 200;
    public float scaler;

    private bool wantToFadeOut = false;
    public int fadeSpeed = 5;

    public float health = 20;
    void Start()
    {
        //Starts at a random location on the map
        sh = GameObject.Find("Ship").GetComponent<ship>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        //transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1 , 0);
        if (directionHasBeenSet)
        {
            transform.position += initialDirectionOfShip;
        }
        if (wantToFadeOut)
        {
            fadeSelf(-1);
        }
        //if it is out of a certain range off screen auto destry
        //if (distance(sh.transform.position.x, sh.transform.position.y) > 30)
        //{
        //    Destroy(gameObject);
        //};

    }
    // pass in negative number to fade out.
    public void fadeSelf(int outOrInt)
    {
        Color color = this.GetComponent<SpriteRenderer>().material.color;
        color.a += Time.deltaTime * fadeSpeed * outOrInt;
        this.GetComponent<SpriteRenderer>().material.color = color;
        if (color.a >= 1)
        {
            wantToFadeOut = false;
        }
        if (color.a <= 0)
        {
            wantToFadeOut = false;
        }
    }
    public void makeSureAstIsVisible()
    {
        wantToFadeOut = false;
        Color color = this.GetComponent<SpriteRenderer>().material.color;
        color.a = 1;
        this.GetComponent<SpriteRenderer>().material.color = color;
        turnOnCollider();
    }
    public void setDirectionOfShipFromCurrentPos(ship target)
    {
        sh = target;
        Vector3 v3 = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0).normalized/getSpeedScale();
        initialDirectionOfShip = v3;
        directionHasBeenSet = true;
    }
    private float getSpeedScale()
    {

        return (scaler + 0.6f) * speedScaler;
    }
    
    float distance(float otherX, float otherY)
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - otherX, 2) + Mathf.Pow(transform.position.y - otherY, 2));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Colliding w the ship
        if (collision.gameObject.name == "Ship")
        {
            turnOffCollider();
            directionHasBeenSet = false;
            wantToFadeOut = true;
            GameObject.Find("Ship").GetComponent<ship>().astroidHit();
            //Play Sound
            //Change the asteroid images
            //Destroy the asteroid

            //Edit the ships health
        }
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            health -= projSpawner.hitPower;
            if (health <= 0)
            {
                turnOffCollider();
                directionHasBeenSet = false;
                wantToFadeOut = true;
            }
        }

        //if (collision.gameObject.name)
        //Debug.Log($"hit: {collision.gameObject.name}");
        //Debug.Log($"...asteroid hit...");
    }
    public void turnOffCollider()
    {
        gameObject.GetComponent<Rigidbody>().Sleep();
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void turnOnCollider()
    {
        gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
