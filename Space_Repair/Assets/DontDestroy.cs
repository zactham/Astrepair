using System.Collections;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake ()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
