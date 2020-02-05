using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    public ship ship;
	[SerializeField] private HealthBar healthBar;
    

    // Start is called before the first frame update

    void Update () {
        Debug.Log(ship.health);

    }
    private void Start()
    {
    	float health = 1f;
    	FunctionPeriodic.Create(() => {
    		if (health > .01f) {
    			health -= .01f;
    			healthBar.SetSize(health);
    			if (health < .3f) {
    				healthBar.SetColor(Color.red);			
    			}
   				
    		}

    	}, .3f);
 

    }

   
}
