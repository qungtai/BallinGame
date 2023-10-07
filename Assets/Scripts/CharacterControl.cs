using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody rigidbody;
    private GameObject focalPoint;
    public bool isPowerUp = false;
    private SpawnManager spawn;
    public GameObject powerIndicator;

    public float movingSpeed;
    [FormerlySerializedAs("powerUpTime")] [SerializeField] private float powerUpTimeFirst = 5;
    [FormerlySerializedAs("powerUpTimeCopy")] public float powerUpTime;
    public float powerUpStrength = 15;
    public int DiamondCount;  
    bool IsStartCountDown = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        powerUpTime = powerUpTimeFirst;
    }
    void FixedUpdate()
    {
        float direction = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * direction   * movingSpeed);
        if (transform.position.y <= -4)
        {
            OnLose();
        }
        
        powerIndicator.transform.position = transform.position;
        if (isPowerUp)
        {
            powerIndicator.gameObject.SetActive(true);
        } 
        else powerIndicator.gameObject.SetActive(false);

        if (IsStartCountDown)
        {
            powerUpTime -= Time.deltaTime;
        }

        if (powerUpTime <= 0)
        {
            IsStartCountDown = false;
            powerUpTime = powerUpTimeFirst;
        }
        
    }

    private void OnLose()
    {
        DataPaste.Time = string.Format("{0:00}:{1:00}",Mathf.FloorToInt(spawn.remainingTime / 60),Mathf.FloorToInt(spawn.remainingTime % 60));
        DataPaste.Diamond = DiamondCount;
        DataPaste.Level = spawn.level;
        SceneManager.LoadSceneAsync("Scenes/ScoreScene");
        Time.timeScale = 1;
    }

    IEnumerator effectiveTimeOfPower()
    {
        yield return new WaitForSeconds(powerUpTimeFirst);

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
            DiamondCount++;
            IsStartCountDown = true; 
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
