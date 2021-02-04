using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_beam : MonoBehaviour {

	public int shoot_level;


	// Use this for initialization
	void Start () {
		GameObject thePlayer = GameObject.Find("Player");
		FlyControl player = thePlayer.GetComponent<FlyControl>();
		shoot_level = player.weapon_lvl;
        this.transform.GetChild(0).gameObject.SetActive(shoot_level == 1);
        this.transform.GetChild(1).gameObject.SetActive(shoot_level == 2);
        this.transform.GetChild(2).gameObject.SetActive(shoot_level == 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
