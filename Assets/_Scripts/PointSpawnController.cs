using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnController : MonoBehaviour {
    public GameObject smallPoint;
    public GameObject bigPoint;
    public GameObject player;
    private Transform playerTrans;

    public float initHight;

    public float leftEdge;
    public float rightEdge;

    public float minHight;
    public float maxHight;

    private float nextHight;
    //private float nowHight;
    
	// Use this for initialization
	void Start () {
        init();
        playerTrans = player.transform;
        Instantiate(smallPoint, new Vector3(Random.Range(leftEdge, rightEdge), initHight, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        spawn();
	}
    void init()
    {
        nextHight = initHight;
    }

    void spawn()
    {
        Vector3 pointPos = new Vector3(0, 0, 0);
        if (nextHight - playerTrans.position.y < 3)
        {
            for(int i = 0; i < 3; i++)
            {
                nextHight +=Random.Range(minHight, maxHight);
                pointPos.x = Random.Range(leftEdge, rightEdge);
                pointPos.y = nextHight;
                Instantiate(smallPoint, pointPos, Quaternion.identity);
            }
        }
    }
}
