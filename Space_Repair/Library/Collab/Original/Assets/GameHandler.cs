using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    public ship sh;
    public float health = 1f;
    [SerializeField] private HealthBar healthBar;

    
    

    // Start is called before the first frame update

    void Update () {
        health = sh.getHealth();

    }
    private void Start()
    {
    	FunctionPeriodic.Create(() => {
    		if (health > .01f) {
    			health -= .01f;
    			healthBar.SetSize(health);
    			if (health < .1f) {
    				healthBar.SetColor(Color.red);			
    			}
   				
    		}

    	}, .3f);
 

    }

   
}
