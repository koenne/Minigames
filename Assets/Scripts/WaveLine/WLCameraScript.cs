using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WLCameraScript : MonoBehaviour
{
    public Rigidbody2D playerRb;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, playerRb.transform.position.y + 2.5f, -10);
    }
}
