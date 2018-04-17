using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour {

    public GameObject destroyDustPar;
    public GameObject toucher;
    private Vector3 cameraPos;
    private Vector3 screenBottomPos;
    private bool isTouch = false;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        cameraPos = Camera.main.transform.position;
        screenBottomPos = Camera.main.ScreenToWorldPoint(new Vector3(0, -Camera.main.pixelHeight/2, 0));
        //Debug.Log()
        if (this.transform.position.y < screenBottomPos.y + 1)
        {
            Destroy(this.gameObject);
        }
	}
    void Touch()
    {
        isTouch = true;
    }
    public void setToucher(GameObject Toucher)
    {
        toucher = Toucher;
        //Debug.Log(toucher);
    }
    private void OnDestroy()
    {
        //Instantiate();
        if (isTouch)
        {
            GameObject go = Instantiate(destroyDustPar, this.transform.position, Quaternion.identity) as GameObject;
            //go.SendMessage("setToucher", toucher);
            go.GetComponentInChildren<PointDestroyDustController>().player = toucher;
        }
    }

}
