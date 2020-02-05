using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public ship sh;
    public RayGun_Spawner rgs;

    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            rgs.sh.setCanShoot(true);
           
        }
        Destroy(gameObject);


    }
}
