using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienProjectile : MonoBehaviour
{
    private ship sh;
    // Start is called before the first frame update\
    private float speedScaler = 0.1f;
    private Vector3 initialDirectionOfShip;
    public bool directionHasBeenSet = false;
    void Start()
    {
        //Debug.Log("started. ");
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (directionHasBeenSet)
        {
            //Debug.Log("shooting at ship.");
            //initialDirectionOfShip += initialDirectionOfShip;
            transform.position += (initialDirectionOfShip * speedScaler);
        }

    }
    public void setDirectionOfShipFromCurrentPos(ship target)
    {
        sh = target;
        Vector3 v3 = ((target.transform.position - transform.position) * speedScaler).normalized;
        initialDirectionOfShip = new Vector3(v3.x, v3.y, 0);
        directionHasBeenSet = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            Destroy(gameObject);
        }
    }

}
