using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedparticle : MonoBehaviour {

    private ParticleSystem ThisParicleSystem;

	// Use this for initialization
	void Start () {
        ThisParicleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ThisParicleSystem.isPlaying)
            return;
        
        Destroy(gameObject);
	}

    void OnBecomeInvisible(){
        Destroy(gameObject);
    }
}
