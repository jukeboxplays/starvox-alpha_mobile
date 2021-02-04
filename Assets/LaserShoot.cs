


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour {

    public Rigidbody laserBeam;
    public int not_active;
    public float laserSpeed = 200.0f;
    public float laserLife = 1.0f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
        
        if (Input.GetButtonDown("Fire1")) {
            Rigidbody clone_laserBeam = Instantiate(laserBeam, transform.position, transform.rotation) as Rigidbody; //transform.position ou rotation  OU deve ser laserBeam.position ou rotation
            clone_laserBeam.AddForce(transform.forward * laserSpeed * Time.deltaTime*50, ForceMode.VelocityChange);
            Destroy(clone_laserBeam.gameObject, laserLife);

        }
    }

		
	
}
