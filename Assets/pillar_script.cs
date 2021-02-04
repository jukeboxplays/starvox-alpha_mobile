using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar_script : MonoBehaviour {

	float xSpin;
    float ySpin;
    float zSpin;
    float xScale;
    float yScale;
    float zScale;
    GameObject player;

	// Use this for initialization
	  void Start () {
        player = GameObject.FindWithTag("Player");
           
    
    }
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.z < player.transform.position.z - 200f){
			Destroy(this.gameObject);
		}
	}
}
