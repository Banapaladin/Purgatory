using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int LevelToLoad;
	
	public void LoadLevel() {
        SceneManager.LoadScene(LevelToLoad);
	}
	
	// Update is called once per frame
	public void  LevelExit() {
        Application.Quit();
	}
}
