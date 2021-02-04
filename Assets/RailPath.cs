using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPath : MonoBehaviour {

    public float speed = 50.0f;
    
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * (Time.deltaTime);
	}
}