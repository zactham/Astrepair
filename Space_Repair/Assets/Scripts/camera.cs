using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float moveSpeed = 1.0f;
    private float startZ;
    void Start()
    {
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, startZ);
        transform.position = Vector3.Lerp(transform.position, newPos, moveSpeed * Time.deltaTime);
    }
}
