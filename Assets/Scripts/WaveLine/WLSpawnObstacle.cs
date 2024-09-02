using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class WLSpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;
    private float timer = 0.0f;
    private float newTime = 2;
    private int xPos;
    public GameObject player;
    private bool start = false;
    private WLPlayerScript WLPlayerScript;
    // Update is called once per frame
    private void Start()
    {
        WLPlayerScript = player.GetComponent<WLPlayerScript>();
    }
    void Update()
    {
        if (!WLPlayerScript.isDead)
        {
            if (Input.GetMouseButtonDown(0) && !start)
            {
                start = true;
            }
            if (start)
            {
                timer += Time.deltaTime;
                if (timer > newTime)
                {
                    newTime = Random.Range(0.9f, 1.6f);
                    timer = 0.0f;
                    xPos = Random.Range(-4, 5);
                    Instantiate(obstacle, new Vector3(xPos, player.transform.position.y + 20f, 1f), transform.rotation);
                }
            }
        }
        else if(start)
        {
            start = false;
        }
    }
}
