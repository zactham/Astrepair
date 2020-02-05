using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partCollector : MonoBehaviour
{
    public leftWing lWing;
    public RightWing rWing;
    public Middle_Piece midP;
    public AsteroidSpawner spawner;
    private ship gameShip;
    private float scalePartAway = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.gameShip = GameObject.Find("Ship").GetComponent<ship>();
        putLeftPieceRandom();
        putMiddlePieceRandom();
        putRightWingRandonm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void putLeftPieceRandom()
    {
        //Vector3 rnd = spawner.getRandomVector3InZ0();
        Vector3 rnd = new Vector3(-10, 0, 0);
        leftWing l = Instantiate(lWing, rnd, Quaternion.identity);
        gameShip.setLWing(l);
    }

    public void putMiddlePieceRandom()
    {
        //Vector3 rnd = spawner.getRandomVector3InZ0();
        Vector3 rnd = new Vector3(-10, 10, 0);
        Middle_Piece mp = Instantiate(midP, rnd, Quaternion.identity);
        gameShip.setMPiece(mp);
    }

    public void putRightWingRandonm()
    {
        //Vector3 rnd = spawner.getRandomVector3InZ0();
         Vector3 rnd = new Vector3(10, 10, 0);
        RightWing rw = Instantiate(rWing, rnd, Quaternion.identity);
        gameShip.setRWing(rw);
    }
}
