using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP : MonoBehaviour {

    public int maxH = 100, currentH = 100;
    public float hBarSize;
    public Vector2 targetPosition;
    public GameObject gridController;

    void Start() {

        hBarSize = Screen.width / 6;
        gridController = GameObject.Find("Grid Maker");

    } // Start

    
    void Update() {

        if (currentH <= 0)
        {
            Destroy(this.gameObject);
            Score.score += 15;

            gridController.GetComponent<Grid>().gold += 25;
        }
        
    } // Update

    void OnGUI() {

        targetPosition = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Box(new Rect(targetPosition.x - 25, Screen.height - targetPosition.y - 40, 60, 20), currentH + "/" + maxH);

    } //OnGui

} // HP
