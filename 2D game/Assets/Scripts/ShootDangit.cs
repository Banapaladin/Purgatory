using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDangit : MonoBehaviour {

    public Transform FirePoint;
    public GameObject projectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectile,FirePoint.position, FirePoint.rotation);
	}
}
