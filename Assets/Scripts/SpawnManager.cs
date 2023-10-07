using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enermy;
    public GameObject diamond;
    private float spawnTime = 5;
    private float firstDelay = 1;
    private Vector3 positionSpawn;
    //public GameObject characterController;
    private bool instanteDiamondAccepted = false; 
    public int enermyNum;
    public int level = 1;

    public float remainingTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        instanteDiamondAccepted = GameObject.Find("Character").GetComponent<CharacterControl>().isPowerUp;//powerUp expire then accept to instante new Diamond
        InstanteDiamond();
        SpawnEnermyWaves(level);    
    }

    public static void OnLose()
    {
        
    }
    void Update()
    {
        
        enermyNum = FindObjectsOfType<EnemyController>().Length;
        if (enermyNum == 0)
        {
            level++;
            SpawnEnermyWaves(level);
            
        }
        if(instanteDiamondAccepted)
        {
            InstanteDiamond();
            instanteDiamondAccepted = false;
        }
        RemainingTime();
    }

    void RemainingTime()
    {        
        remainingTime += Time. deltaTime;
    }
    void SpawnEnermyWaves(int numberOfEnermy)
    {
        for (int i = 0; i < numberOfEnermy; i++)
        {
            InstanteEnermy();
        }
    }

    void SpawnDiamond(float numberOfDiamod)
    {
        for (int i = 0; i < numberOfDiamod; i++)
        {
            InstanteDiamond();
        }
    }
    void InstanteEnermy()
    {
        Instantiate(enermy, GenerateRandomPointInHexagon(Vector3.zero,14) + new Vector3(0,2,0),enermy.transform.rotation,null);// let the enermy falling from the sky
    }
    public void InstanteDiamond()
    {
        Instantiate(diamond, GenerateRandomPointInHexagon(Vector3.zero,14), enermy.transform.rotation, null);
    }
    public Vector3 GenerateRandomPointInHexagon(Vector3 center, float radius)
    {

        float angle = 30f;
        float angleRad = angle * Mathf.Deg2Rad;
        float incircleRadius = radius * Mathf.Sin(angleRad);
        float height = radius * Mathf.Cos(angleRad);

        float randomAngle = Random.Range(0f, 360f);
        float randomRadius = Random.Range(0f, incircleRadius);
        float x = center.x + randomRadius * Mathf.Cos(randomAngle);
        float z = center.y + randomRadius * Mathf.Sin(randomAngle);
        float y = 0;
        return new Vector3(x, y, z);
    }
}