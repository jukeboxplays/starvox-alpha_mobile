using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlusGetShot : MonoBehaviour
{

    public GameObject olusDummy;
    public GameObject laserBeam_hit;
    private GameObject clone_olusDummy;
    public static int addScore;
    private Transform rock;
    float xSpin;
    float ySpin;
    float zSpin;
    float xScale;
    float yScale;
    float zScale;
    GameObject player;
    

    void Start () {
        player = GameObject.FindWithTag("Player");
        xSpin = Random.Range(0,50);
        ySpin = Random.Range(0,50);
        zSpin = Random.Range(0,50);
        xScale = Random.Range(-20f,20f);
        yScale = Random.Range(-20f,20f);
        zScale = Random.Range(-20f,20f);
        rock = olusDummy.transform.GetChild(Random.Range(0,4));
        rock.gameObject.SetActive(true);
        rock.localScale += new Vector3(xScale,yScale,zScale);
    
    
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate (new Vector3 (xSpin, ySpin, zSpin) * Time.deltaTime);
        if(this.transform.position.z < player.transform.position.z - 200f){
			Destroy(olusDummy.gameObject);
		}
    }
     

    //public void OnTriggerEnter(Collider col)
    //{
        //ScoreBoard.score += 100;
    //    addScore += 50;
    //    Debug.Log("+50");
    //   Destroy(olusDummy.gameObject);
        
    //}




}