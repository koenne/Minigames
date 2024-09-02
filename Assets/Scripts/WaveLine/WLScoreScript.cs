using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WLScoreScript : MonoBehaviour
{
    public TMP_Text textMeshProUGUI;
    int score = 0;
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.SetText("Score: " + score);
    }
    public void GiveScore()
    {
        score++;
        textMeshProUGUI.SetText("Score: " + score);
    }
    public void playerDied()
    {
        StartCoroutine(Wait());
    }
    public void playerAlive()
    {
        score = 0;
        textMeshProUGUI.SetText("Score: " + score);
        textMeshProUGUI.margin = new Vector4(0, 0, -300, 0);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        textMeshProUGUI.SetText("Score: " + score);
        textMeshProUGUI.margin = new Vector4(1000, 500, -1500, 0);
    }
}
