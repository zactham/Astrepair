using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWing : MonoBehaviour
{
    // Start is called before the first frame update

    private bool pickedUp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
 
            Vector2 v2Pos = new Vector2(0.75f, 0.8f);
            Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(v2Pos);
            spawnLoc.z = 0;

            transform.position = spawnLoc;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            pickedUp = true;
        }
    }
}
