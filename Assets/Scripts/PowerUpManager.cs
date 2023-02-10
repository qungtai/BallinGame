using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class PowerUpManager : MonoBehaviour
{
    public GameObject diamond;
    // Start is called before the first frame update
    void Start()
    {
        diamond = this.gameObject;
    }

    // Update is called once per frame
   
    void Update()
    {
        
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(diamond);
    //     }
    // }
}