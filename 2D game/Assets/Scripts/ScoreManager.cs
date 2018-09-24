using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int Score;

    Text ScoreText;

	private void Start(){
        ScoreText = GetComponent<Text>();

        Score = 0;
	}

	private void Update(){
        if (Score < 0)
            Score = 0;

        ScoreText.text = " " + Score;
	}

    public static void AddPoints (int PointsToAdd) {
        Score += PointsToAdd;
    }

    public static void Reset () {
        Score = 0;
    }


}