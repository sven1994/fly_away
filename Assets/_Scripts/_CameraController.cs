using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CameraController : MonoBehaviour {
    public GameObject player;
    public Transform playertrans;
    public float speed;
	// Use this for initialization
	void Start () {
        playertrans = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (playertrans.position.y>this.transform.position.y)
        {
            float lerpY = Mathf.Lerp(this.transform.position.y, playertrans.position.y, speed);
            this.transform.position = new Vector3(this.transform.position.x, lerpY, this.transform.position.z);
        }
	}
}
