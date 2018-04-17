using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int MaxLife = 100;
    public float MoveSpeed=0.1f;
    [HideInInspector]
    public int currentLife;

    public float reduceLifeTime;
    private float lifeTimeCounter=0;
	// Use this for initialization
	void Start () {
        currentLife = MaxLife;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        if (reduceLifeTime < lifeTimeCounter)
        {
            currentLife -= 1;
            lifeTimeCounter = 0;
        }  
        else
            lifeTimeCounter += Time.deltaTime;
	}
    void Move()
    {
        Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mosPos.z = 0;
        Vector3 centralPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2,0));
        //Vector3 centralPos = this.transform.position;
        centralPos.z = 0;
        Vector3 dir = mosPos - centralPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        this.transform.Translate(this.transform.InverseTransformDirection(this.transform.right*MoveSpeed)); 
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            collision.gameObject.SendMessage("Touch");
            collision.gameObject.SendMessage("setToucher", this.gameObject);
            Destroy(collision.gameObject);
        }
    }
    public void yes()
    {
        Debug.Log(1111);
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("Character"))
        {  
            other.SendMessage("yes");
        }

    }
    public void AddLifeTime()
    {
        currentLife = Mathf.Clamp(currentLife + 1, 0, MaxLife);
        //Debug.Log(currentLife);
    }

}
