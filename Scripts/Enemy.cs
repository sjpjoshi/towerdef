using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float x, y, z, speed;

    public int stage;
    public Vector3 cv, v3;
    public GameObject grid, gameObject;
    
    void Start() {

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        y++;
        z = 3;
        transform.position = new Vector3(x, y, z);

        stage = 0;
        cv = transform.position;
        grid = GameObject.Find("Grid Maker");

    } // Start


    void Update() {

        if(stage < 15)
            nextStage(stage);
        cv = transform.position;
        speed = 5f;
        transform.position = Vector3.MoveTowards(cv, v3, speed * Time.deltaTime);

        if (cv == v3)
            stage++;

        if (stage == 15) {

            v3.z += 3;
            stage = 100;

        } // if

        if (stage == 101 && cv == v3) {

            LP.points--;
            Destroy(gameObject);

        } // if

    } // Update

    public void nextStage(int s) {

        v3 = grid.GetComponent<Grid>().pathways[s].transform.position;
        v3.y = 1;

    } // nextStage

} // Enemy
