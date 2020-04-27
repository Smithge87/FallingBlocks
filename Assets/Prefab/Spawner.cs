﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    Vector2 screenHalfSizeWorldUnits;
    public Vector2 secondsBetweenSpawnMinMax;
    float nextSpawnTime;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            //-- update spawn time
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            //-- randomly generate size and placement
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            //-- generate a new block
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }        
    }
}
