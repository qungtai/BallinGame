using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    private GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        _gameObject = this.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }
}
