using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private GameObject character;
    public Transform target;
    public Rigidbody enermyRb;
    public float speed;
    //public float minDist = 1f;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");
        
    }
    // Update is called once per frame
    void Update()
    {
        enermyRb.AddForce((character.transform.position - transform.position).normalized * speed);
    }
    // void Update()
    // {
    //     if (target == null)
    //         return;
    //     // face the target
    //     transform.LookAt(target);
    //     //get the distance between the chaser and the target
    //     float distance = Vector3.Distance(transform.position, target.position);
    //     //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
    //     if (distance > minDist)
    //         transform.position += transform.forward * speed * Time.deltaTime;
    // }
    // // Set the target of the chaser
    // public void SetTarget(Transform newTarget)
    // {
    //     target = newTarget;
    // }
}
