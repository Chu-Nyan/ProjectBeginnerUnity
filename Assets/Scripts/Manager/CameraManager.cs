using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject following;
    float followX;
    float followY;


    void LateUpdate()
    {
        followX = following.transform.position.x;
        followY = following.transform.position.y;
        transform.position = new Vector3 (followX, followY, transform.position.z);
    }
}
