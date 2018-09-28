using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();	
	}

	void OnTriggerEnter2D(Collider2D collision){
        if(other.name == "PC"){
            levelManager.CurrentCheckPoint = gameObject;
            Debug.Log("Activated Checkpoint" + transform.position);
        }
	}
}
