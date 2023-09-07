using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleport : MonoBehaviour
{
    [SerializeField]
    float telX = 0;
    [SerializeField]
    float telY = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float telZ = collision.gameObject.transform.position.z;
            collision.gameObject.transform.position = new Vector3(telX, telY, telZ);
        }
    }

}
