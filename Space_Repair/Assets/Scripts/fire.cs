using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public ship ship;
    private bool wantToFadeOut = false;
    private float fadeSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        toggleAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fadeSelf(1);
        }else {
            toggleAlpha(0);
        }
    }
    void toggleAlpha(int offOrOn)
    {
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.a = offOrOn;
        GetComponent<SpriteRenderer>().material.color = color;
    }
    public void fadeSelf(int outOrInt)
    {
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.a += Time.deltaTime * fadeSpeed * outOrInt;
   
        if (color.a >= 1)
        {
            wantToFadeOut = false;
        }else if (color.a <= 0)
        {
            wantToFadeOut = false;
        } else
        {
            GetComponent<SpriteRenderer>().material.color = color;
        }
    }
}
