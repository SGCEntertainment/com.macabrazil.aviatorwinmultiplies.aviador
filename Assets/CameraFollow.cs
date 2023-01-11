using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform doodlePos;

    void Update()
    {
        if (doodlePos.position.x > transform.position.x) 
        {
            transform.position = new Vector3(doodlePos.position.x, transform.position.y, transform.position.z);
        }
    }
}
