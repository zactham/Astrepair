using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public float moveSpeed = 0.1f;  // Units per second;
    public float health = 5;
    private Vector2 relativeMovement = new Vector2(0, 0);
    private bool motionSet = false;
    public float speed = 5f;
    private int scaleDownSpeed = 30;
    public int score = 0;
    private leftWing lWing;
    private Middle_Piece midp;
    private RightWing rWing;

    private bool canShoot = false;
    
    // Start is called before the first frame update
    void Start()
    {
      //  lWing = GameObject.Find("")
    }
    public void setLWing(leftWing l)
    {
        lWing = l;
    }
    public void setRWing(RightWing r)
    {
        rWing = r;
    }
    public void setMPiece(Middle_Piece m)
    {
        midp = m;
    }
    public void setCanShoot(bool yes)
    {
        canShoot = yes;

    }

    public bool getCanShoot()
    {
        return canShoot;

    }

    public void changeHealthBy(int h)
    {
        health += h;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log($"Detected shift.");
            lWing.follow();
        }

        // when mouse click then move in direction.
        if(Input.GetMouseButton(0))
        {
            var pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            // update the relative motion to where the ship is facing (which is based on the mouse position)
            if (motionSet)
            {
                relativeMovement += (pos - new Vector2(transform.position.x, transform.position.y)).normalized/scaleDownSpeed;
            } else
            {
                relativeMovement = (pos - new Vector2(transform.position.x, transform.position.y)).normalized / scaleDownSpeed;
            }
            Debug.Log(relativeMovement);
           
            motionSet = true;
        }

        transform.position += new Vector3(relativeMovement.x, relativeMovement.y, 0) / scaleDownSpeed;

    }

    public Vector2 getRelativeVector2()
    {
        return new Vector2(relativeMovement.x, relativeMovement.y);
    }

    void LookAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.up = direction;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"touching... {collision.gameObject.name}");
        //if (collision.gameObject.name)
        if (collision.gameObject.name == "leftWing(Clone)") { 
        
            lWing.canMove = true;
            lWing.goToPlatform();
        }

        //if (collision.gameObject.name == "Astroid(Clone)") {
         //   health -= 5;
        //}
       

    }
    void OnCollisionEnter2D () {
        if (health == 0f || health < 0f) {
                GameControl.instance.GameOver();
            }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log($"touching... {collision.gameObject.name}");
        if (collision.gameObject.name == "leftWing(Clone)")
        {
            lWing.canMove = false;
            lWing.goToPlatform();
        }
    }
}
