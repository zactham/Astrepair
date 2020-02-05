using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftWing : MonoBehaviour
{
    public bool canMove = false;
    public ship ship;
    private Vector3 relPosition;
    private bool positionSet = false;
    private bool pickedUp = false;
    // Start is called before the first frame update
    const float REFERENCE_FRAMERATE = 30f;
    public float followSharpness = 0.1f;
    Vector3 _followOffset;

    void Start()
    {
        //   goToPlatform();
    }

    // Update is called once per frame
    void Update()
    {

        if (pickedUp)
        {
           
            Vector2 v2Pos = new Vector2(0.7f, 0.8f);
            Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(v2Pos);
            spawnLoc.z = 0;

            transform.position = spawnLoc;
        }

    }
    void LateUpdate()
    {

    }
    public void follow()
    {
        Debug.Log("following...");
        if (canMove)
        {
            float timeRatio = Time.deltaTime * REFERENCE_FRAMERATE;
            float adjustedSharpness = 1f - Mathf.Pow(1f - followSharpness, timeRatio);

            transform.position += (ship.transform.position - transform.position) * adjustedSharpness;
        }
    }

    public void setFollow()
    {
        _followOffset = transform.position - ship.transform.position;
    }
    public void goToPlatform()
    {
        transform.position = new Vector3(-1f, 4f, 0);
    }

    public void goToScreen()
    {
        transform.position = new Vector3(-1f, 4f, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            pickedUp = true;
        }
    }
}
