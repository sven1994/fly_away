using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUIController : MonoBehaviour {

    public Slider LifeSlider;
    public GameObject player;
    private PlayerController playerCon;
	// Use this for initialization
	void Start () {
        LifeSlider = GetComponent<Slider>();
        playerCon = player.GetComponent<PlayerController>();
        LifeSlider.maxValue = playerCon.MaxLife;
        LifeSlider.value = playerCon.MaxLife;

    }
	
	// Update is called once per frame
	void Update () {
        LifeSlider.value = playerCon.currentLife;
	}
}
