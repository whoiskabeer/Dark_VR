﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    GameObject enemy;
    GameObject floor;
    Mesh planeMesh;
    Bounds bounds;
    Vector3 randomPointOnPlane;
    public float spawnTime = 4;



    void Start(){
        enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        floor = GameObject.FindWithTag("Floor");
		planeMesh = floor.GetComponent<MeshFilter>().mesh;
        bounds = planeMesh.bounds;
        enemy.transform.position = new Vector3(10,10,10);
        Spawn ();
        Invoke("Spawn", spawnTime);
	}



    //spawn an enemy at a random location 
    void Spawn () {
        float randomX = Random.Range(floor.transform.position.x - (floor.transform.localScale.x / 2) * bounds.size.x, 
                                     floor.transform.position.x + (floor.transform.localScale.x / 2) * bounds.size.x);
        float randomY = Random.Range(floor.transform.position.y - (floor.transform.localScale.y / 2) * bounds.size.y,
                                     floor.transform.position.y + (floor.transform.localScale.y / 2) * bounds.size.y);
        float randomZ = Random.Range(floor.transform.position.z - (floor.transform.localScale.z / 2) * bounds.size.z,
									 floor.transform.position.z + (floor.transform.localScale.z / 2) * bounds.size.z);
        randomPointOnPlane =  new Vector3(randomX, randomY, randomZ);
        Instantiate(enemy, randomPointOnPlane, Quaternion.identity);
    }


 
}