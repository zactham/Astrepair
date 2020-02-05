using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Alien_Here", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
