using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {


    public GameObject enemy, enemy2, enemy3, spawnPoint, Grid;
    public Text waveText;
    public bool[] wave;
    public int timer;
    public bool coroutine, stop;

    void Start() {

        timer = 10;
        stop = true;

    } // Start

   
    void Update() {

        spawnPoint = Grid.GetComponent<Grid>().pathways[0];
        waveText.text = timer + " Seconds";

        if (coroutine == false) {

            StartCoroutine(Second());
            coroutine = true;

        } // if

        if (timer <= 0) {

            if (stop == true) {

                timer = 30;
                stop = false;
                CalculateWaves();

            } else {

                timer = 10;
                stop = true;

            } // else

        } // if
         
    } // Update


    public void CalculateWaves() {

        if (stop == false && wave[0] == false && wave[1] == false && wave[2] == false)
            wave[0] = true;
        else if (stop == false && wave[0] == true && wave[1] == false && wave[2] == false)
            wave[1] = true;
        else if (stop == false && wave[0] == true && wave[1] == true && wave[2] == false)
            wave[2] = true;
        else if (stop == false && wave[0] == true && wave[1] == true && wave[2] == true) {

            wave[0] = false;
            wave[1] = false;
            wave[2] = false;
            CalculateWaves();

        } // else if

    } // CalculateWaves

    IEnumerator Second() {

        yield return new WaitForSeconds(1f);
        timer--;
        coroutine = false;


        if (stop == false && wave[0] == true && wave[1] == false && wave[2] == false)
            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        if (stop == false && wave[0] == true && wave[1] == true && wave[2] == false)
            Instantiate(enemy2, spawnPoint.transform.position, Quaternion.identity);
        if (stop == false && wave[0] == true && wave[1] == true && wave[2] == true)
            Instantiate(enemy3, spawnPoint.transform.position, Quaternion.identity);


    } // Second


} // EnemySpawner
