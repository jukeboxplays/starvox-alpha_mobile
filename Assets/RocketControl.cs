using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour {

    public GameObject L_rkt;
    public GameObject R_rkt;

    public bool L_Rocket;
    public bool R_Rocket;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (L_Rocket)
        {
            //this.transform.rotation = Quaternion.Inverse(L_rkt.transform.rotation);
            this.transform.rotation = L_rkt.transform.rotation;
        }


        if (R_Rocket)
        {
            //this.transform.rotation = Quaternion.Inverse(R_rkt.transform.rotation);
            this.transform.rotation = R_rkt.transform.rotation;
        }
    }
}
