using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

	private Transform bar;
    // Start is called before the first frame update
    private ship ship;

    void Start() {
        GameObject ship = GameObject.Find("Ship");
        this.ship = ship.GetComponent<ship>();
    }
  
    void Update () {
        if (ship != null){
               //Debug.Log(ship.health);
        }
        Vector2 v2Pos = new Vector2(0.5f, 0.1f);
        Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(v2Pos);
        spawnLoc.z = 0;

        transform.position = spawnLoc;
    }
    private void Awake()
    {
    	//bar = transform.Find("Bar");
    	bar = transform.Find("Bar");
    	//bar.localScale = new Vector3 (.4f, 1f);        
    }

    public void SetSize (float sizeNormalized) {

    	bar.localScale = new Vector3(sizeNormalized, 1f);

    }

    public void SetColor (Color color) {
    	bar.Find("Bar Sprite").GetComponent<SpriteRenderer>().color = color;
    }

   
}
