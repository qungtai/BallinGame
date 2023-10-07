using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y <= -3)
        {
            Destroy(this.gameObject);
        }
    }
}
