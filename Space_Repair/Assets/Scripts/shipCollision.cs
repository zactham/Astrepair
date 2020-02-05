using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipCollision : MonoBehaviour
{
    public ship shipToTrack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = shipToTrack.transform.position;
        transform.rotation = shipToTrack.transform.rotation;
    }
}
