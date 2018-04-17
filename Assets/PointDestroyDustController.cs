using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDestroyDustController : MonoBehaviour {

    public GameObject player;
    public float waitTime;
    public float speed;
    private ParticleSystem partSys;
    private ParticleSystem.Particle[] thePart;
    private ParticleSystem.Particle[] trackedPar;
    private int partcount;
    private float timeCounter;
    private enum _Status {start,stop,track};
    private _Status status=_Status.start;
    private Color32 parColor;
    private int trackedCount=0;

    // Use this for initialization
    void Start () {

        partSys = this.GetComponent<ParticleSystem>();
        thePart = new ParticleSystem.Particle[partSys.main.maxParticles];
        trackedPar= new ParticleSystem.Particle[partSys.main.maxParticles]; 
        parColor =thePart[0].GetCurrentColor(partSys);
        parColor.a = 0;

    }
	
	// Update is called once per frame
	void Update () {
        partcount = partSys.GetParticles(thePart);
        

        switch (status)
        {
            case _Status.start:
                if (partSys.isPlaying)
                {
                    if (waitTime < timeCounter)
                    {
                        status = _Status.stop;
                    }
                    else
                    {
                        timeCounter += Time.deltaTime;
                    }

                }
                break;
            case _Status.stop:
                for (int i = 0; i < partcount; i++)
                {
                    thePart[i].velocity = Vector3.zero;
                }
                status = _Status.track;
                break;
            case _Status.track:
                if (partcount == 0) Destroy(this.transform.parent.gameObject);
                for (int i = 0; i < partcount; i++)
                {
               
                    if (Vector2.Distance(thePart[i].position, player.transform.position) < 0.05)
                    {
                        //thePart[i].startColor = parColor;
                        thePart[i].remainingLifetime = 0;
                        player.SendMessage("AddLifeTime");
                        trackedCount += 1;
                        //Debug.Log(trackedCount);
                            
                    }
                        
                    else
                    {
                        thePart[i].position = Vector3.MoveTowards(thePart[i].position, player.transform.position, speed);
                    }


                }
                break;
                
        }

        partSys.SetParticles(thePart, partcount);
        
        
    }
    private void OnDestroy()
    {
        Debug.Log("Full！！！");
    }

}
