using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    public AudioSource Boop;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Boop.isPlaying)
            {
                Boop.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Boop.Stop();
        }
    }
}