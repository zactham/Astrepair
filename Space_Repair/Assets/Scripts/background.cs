using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    // Start is called before the first frame update
    int currentPosX = -50;
    int currentPosY = -50;
    int step = 50;
    void Start()
    {
        transform.position = new Vector3(currentPosX, currentPosY, 0);
        currentPosX += step;
        currentPosY += step;
        makeAllBackground();
    }

    private void makeAllBackground()
    {
        while(currentPosX < 50)
        {
            for (; currentPosY < 50; currentPosY += step)
            {
                Instantiate(gameObject, new Vector3(currentPosX, currentPosY, 0), Quaternion.identity);
            }
            currentPosY = -50;
            currentPosX += step;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
