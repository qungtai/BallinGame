using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using RemoteNotification = UnityEngine.iOS.RemoteNotification;

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
    public int waveOrder = 1;
    // Start is called before the first frame update
    void Start()
    {
        instanteDiamondAccepted = GameObject.Find("Character").GetComponent<CharacterControl>().isPowerUp;//powerUp expire then accept to instante new Diamond
        //Invoke(nameof(InstanteDiamond),firstDelay);
        //InvokeRepeating(nameof(InstanteEnermy),firstDelay,spawnTime);
        InstanteDiamond();
        SpawnEnermyWaves(waveOrder);    
    }
    
    // Update is called once per frame
    void Update()
    {
        enermyNum = FindObjectsOfType<EnermyController>().Length;
        if(instanteDiamondAccepted)
        {
            InstanteDiamond();
            instanteDiamondAccepted = false;
        }

        if (enermyNum == 0)
        {
            waveOrder++;
            SpawnEnermyWaves(waveOrder);
            
        }
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
        Instantiate(enermy, GenerateRandomPointInHexagon(new Vector3(0,0,0),14) + new Vector3(0,2,0),enermy.transform.rotation,null);// let the enermy falling from the sky
    }
    public void InstanteDiamond()
    {
        Instantiate(diamond, GenerateRandomPointInHexagon(new Vector3(0,0,0),14), enermy.transform.rotation, null);
    }

    Vector3 MakeRandomPosition()
    {
        float xPosition = Random.Range(-12, 12);
        float yPosition = 0;
        float zPosition = Random.Range(-10, 10);
        return new Vector3(xPosition, yPosition, zPosition);
    }

    public Vector3 GenerateRandomPointInHexagon(Vector3 center, float radius)
    {
        ////// At this case, radius equal 14, center equal (0;0;0)
        // Angle between the top vertex and the point on the hexagon boundary (30 degrees)
        float angle = 30f;
        // Convert to radians
        float angleRad = angle * Mathf.Deg2Rad;
        // Get the radius of the inscribed circle (distance from center to middle of edge)
        float incircleRadius = radius * Mathf.Sin(angleRad);
        // Get the height of the hexagon (distance between center and top vertex)
        float height = radius * Mathf.Cos(angleRad);

        // Generate a random point within the hexagon
        float randomAngle = Random.Range(0f, 360f);
        float randomRadius = Random.Range(0f, incircleRadius);
        float x = center.x + randomRadius * Mathf.Cos(randomAngle);
        float z = center.y + randomRadius * Mathf.Sin(randomAngle);
        float y = 0;

        // Return the point as a Vector3
        return new Vector3(x, y, z);
    }
}