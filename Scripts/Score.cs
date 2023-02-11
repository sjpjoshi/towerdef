using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreText, lifeText;
    public GameObject lose;

   
    void Start() {

        score = 0;
        
    } // Start

    void Update() {

        scoreText.text = "Score: " + score;
        lifeText.text = "Game Over | Your score: " + score;

        if (LP.points <= 0)
            lose.SetActive(true);
        
    } // Update

} // Score
