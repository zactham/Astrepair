using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad : MonoBehaviour
{
    Renderer rend;
    public ship gameShip;
    private float speed = 0.0001f;
    Vector3 pos= new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    } 

    // Update is called once per frame
    void Update()
    {
        pos += Quaternion.Euler(0, 180, 180) * gameShip.getRelativeVector2() * speed;
        rend.material.mainTextureOffset = pos;
    }
}
