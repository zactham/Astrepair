using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public GameObject[] levels;

    private Camera mainCamera;

    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        //takes screen width and height and plots it on an X/Y axis (Z will be 0 in this case)
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        //So for every game object inside of levels, we execute loadChildObjects for each sprite
        //in the list
        foreach(GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }

    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;

        //This will give us enough clones to fill the screen
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);

        //we want to clone our product object so we have a mold we can use as a reference
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            //set new clone to become a child object of parent object
            c.transform.SetParent(obj.transform);

            //space them out one after each other
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
}
