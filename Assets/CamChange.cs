using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour {

    bool startState;
    int old_countState = 0;
    int countState = 0;
    int sumInt = 0;

    Vector3 oldPos;
    Quaternion oldRot = new Quaternion(23.28f, -164.806f, 0.0f, 0.0f);
    Vector3 newPos = new Vector3(0.0f, 12.0f, 0.0f);
    Quaternion newRot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        startState = MainMenu.playStarted;
        countState = MainMenu.playCount + sumInt;
        oldPos = new Vector3(1.897f, 2.12f, 8.117f);
        oldRot = new Quaternion(23.28f, -164.806f, 0.0f, 0.0f);
        newPos = this.transform.position;
        newRot = this.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        

        if (!startState && old_countState != 1)
        {
            sumInt = 1;

            Debug.Log("--Start boolean : " + startState + "--old_count: " + old_countState);
            old_countState += sumInt;

            Debug.Log("--old: " + old_countState);
            this.transform.position = oldPos;
            this.transform.rotation = oldRot;
            sumInt = 0;
        }

        if (countState == 1) {
            Debug.Log("--new: " + countState);
            sumInt = 1;
            countState += sumInt;
            Debug.Log("--new after: " + countState);
            this.transform.position = new Vector3(0.0f, 0.0f ,0.0f);
            this.transform.rotation = newRot;

            this.transform.position = newPos;
            this.transform.rotation = newRot;


        }
    }
}
