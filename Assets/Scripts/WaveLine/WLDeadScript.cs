using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLDeadScript : MonoBehaviour
{
    private int amount;
    void FixedUpdate()
    {
        amount++;
        if(amount < 100)
        {
            this.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        }

    }
    public void ResetScale ()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
        amount = 0;
        gameObject.SetActive(false);
    }
}
