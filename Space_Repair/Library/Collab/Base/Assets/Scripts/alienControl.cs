using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienControl : MonoBehaviour
{
    // Start is called before the first frame update
    public ship ship;
    public alienProjectile projectile;
    private float nextActionTime = 0.0f;
    private float period = 200.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtShip();
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
        }

    }
    void LookAtShip()
    {

    }
}
