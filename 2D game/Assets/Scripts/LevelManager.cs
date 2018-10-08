﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckPoint;
    public Rigidbody2D PC;

    //particles
    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    //respawn delay
    public float RespawnDelay;

    //point penalty
    public int PointPenaltyOnDeath;

    //gravitystorage
    private float GravityStore;

    // Use this for initialization
	void Start () {
        //PC = FindObjectOfType<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer(){
        StartCoroutine("RespawnPCCo");
    }

    public IEnumerator RespawnPCCo(){
        //generate death particles
        Instantiate(DeathParticle, PC.transform.position, PC.transform.rotation);

        //hide player
        //PC.enabled = false;
        PC.GetComponent<Renderer>().enabled = false;

        //gravity reset
        GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //point penalty
        ScoreManager.AddPoints(-PointPenaltyOnDeath);

        //debug message
        Debug.Log("PC Respawn");

        //respawn delay
        yield return new WaitForSeconds(RespawnDelay);

        //gravity restore
        PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;

        //match pc's transform position
        PC.transform.position = CurrentCheckPoint.transform.position;

        //show player
        //PC.enabled = true;
        PC.GetComponent<Renderer>().enabled = true;

        //spawn Player
        Instantiate(RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
    }
}
