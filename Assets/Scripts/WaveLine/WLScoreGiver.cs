using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLScoreGiver : MonoBehaviour
{
    public WLScoreScript WLScoreScript;
    private GameObject ScoreObject;
    private void Start()
    { 
        ScoreObject = GameObject.FindGameObjectWithTag("Score");
        WLScoreScript = ScoreObject.GetComponent<WLScoreScript>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            WLScoreScript.GiveScore();
        }

    }
}
