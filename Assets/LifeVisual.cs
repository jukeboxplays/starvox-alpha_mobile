using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeVisual : MonoBehaviour {


    GameObject player;

    Color color;


    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        FlyControl script = player.transform.GetChild(0).GetComponent<FlyControl>();

        //Debug.Log("Red: " + (255f - (script.life * 2.55f)));
        //Debug.Log("Green: " + (script.life * 2.55f));
        //color = new Color((255f - (script.life * 2.55f)), (script.life * 2.55f), 0f, 255f);


        color = new Color(Mathf.Clamp((1 - script.life/100f),0,1), Mathf.Clamp((script.life/100f), 0, 1), 0);

        

        Vector3 theScale = new Vector3(this.transform.localScale.x, script.life * 0.00253f, this.transform.localScale.z);
        this.transform.localScale = theScale;

        this.GetComponent<Renderer>().material.color = color;

    }
}
