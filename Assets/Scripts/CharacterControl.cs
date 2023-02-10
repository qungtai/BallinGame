using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    public float movingSpeed;
   private Rigidbody rigidbody;
    private GameObject focalPoint;
    private float powerUpStrength = 15;
    public bool isPowerUp = false;
    private SpawnManager spawn;
    public GameObject powerIndicator;
    // Start is called before the first frame update
    void Start()
    {
        // We can code like this instead if we change public to private variable
            rigidbody = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("FocalPoint");
            spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    void FixedUpdate()
    {
        float direction = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * direction   * movingSpeed);
        if (transform.position.y <= -4)
        {
            SceneManager.LoadScene("GamePlay");
        }


        
        powerIndicator.transform.position = transform.position;
        if (isPowerUp)
        {
            powerIndicator.gameObject.SetActive(true);
        } 
        else powerIndicator.gameObject.SetActive(false);

    }

    IEnumerator effectiveTimeOfPower()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds disable power and instante new diamond.
        isPowerUp = false;

        yield return new WaitForSeconds(2);
        
        spawn.InstanteDiamond();
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            isPowerUp = true; 
            StartCoroutine(effectiveTimeOfPower());

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enermy") && isPowerUp)
        {
            Rigidbody enermyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enermyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
