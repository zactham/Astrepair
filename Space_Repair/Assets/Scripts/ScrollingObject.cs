using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D rb2d;

    //reference the object ship
    public ship sh;


    // Start is called before the first frame update
    void Start()
    {
        //Checks for a rb2d attached to the game object that the script is attached to
        // and store a reference in rb2d
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
