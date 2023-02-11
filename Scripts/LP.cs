using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LP : MonoBehaviour {

    public Text lifeT;
    public static int points;


   
    void Start() {

        points = 20;

    } // Start

    
    void Update() {

        lifeT.text = " Life Points: " + points;

    } // Update



} //LP
