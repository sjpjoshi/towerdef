using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Grid : MonoBehaviour {

    // vars for the grid
    public GameObject ground;
    public int columnL, rowL;
    public float xAxis, zAxis;


    //for the pathway
    public GameObject path;
    public GameObject[] panels;

    //for using the pathway
    public GameObject[] pathways;
    int[] pathwayIndices = { 3, 13, 23, 24, 25, 26, 36, 46, 56, 66, 76, 75, 74, 84, 94 };

    //for the tower placement
    public GameObject Tower, PlacingText, hitted;
    public bool placing;
    private Ray ray;
    private RaycastHit _hit;

    //for a gold system
    public int gold;

    public Text goldT;


    void Start() {

        // creating our grid
        for (int i = 0; i < columnL*rowL; i++) {

            Instantiate(ground, new Vector3(xAxis + (xAxis * (i % columnL)), 0, zAxis + (zAxis * (i / rowL))), Quaternion.identity); 

        } // for

        CreatePathway();

    } // Start

    
    void Update() {

        
        if (placing == true) {

            if (Input.GetMouseButtonDown(0)) {
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit)) { 
              
                    if (_hit.transform.tag == "grid") {
                        hitted = _hit.transform.gameObject;
                        Vector3 towerPos = hitted.transform.position;
                        GameObject towerHolder = new GameObject("TowerHolder");
                        towerHolder.transform.position = towerPos;
                        Instantiate(Tower, towerPos, Quaternion.identity, towerHolder.transform);
                        placing = false;
                        PlacingText.SetActive(false);

                    } //  if

                } // if
                
            } // if

        } //if

        goldT.text = "$" + gold;

    } // Update

    public void CreatePathway() {

        panels = GameObject.FindGameObjectsWithTag("grid");

        foreach (int index in pathwayIndices) {

            Instantiate(path, panels[index].transform.position, Quaternion.identity);
            Destroy(panels[index]);

        } // foreaach


        for (int i = 0; i < 100; i++) {

            panels[i] = null;

        } // for


        pathways = GameObject.FindGameObjectsWithTag("path");

    } // CreatePathway

    public void BuyTower() {

        if (gold >= 50) {

            gold -= 50;

            PlacingText.SetActive(true);
            placing = true;


        } // if

    } //BuyTower
     

} // Grid 
