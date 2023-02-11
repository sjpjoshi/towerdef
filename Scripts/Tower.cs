using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Tower : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject tower;
    public bool canAttack;
    public int attackPower;
    Vector3 towerPos;
    public float maxDistance = 30f;


    void Start() {

        canAttack = true;
        attackPower = 10;
        towerPos  = tower.transform.position; 

    } // Start

    void Update() {

        if (canAttack == true)
            StartCoroutine(Attack());


    } // Update

    IEnumerator Attack() {


        canAttack = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy")
        .Where(enemy => Vector3.Distance(enemy.transform.position, towerPos) <= maxDistance)
        .ToArray();

        foreach (GameObject enemy in enemies) {

            enemy.GetComponent<HP>().currentH -= attackPower;
            yield return new WaitForSeconds(0.5f);

        } // foreach

        canAttack = true;

    } // Attack

} // Tower
