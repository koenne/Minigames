using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WLPlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private ConstantForce2D customGravity;
    public bool isDead = false;
    public GameObject deadAnimation;
    public WLScoreScript WLScoreScript;
    public GameObject restartButton;
    public WLDeadScript WLDeadScript;
    public TrailRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        customGravity = GetComponent<ConstantForce2D>();
    }
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                changeDirection();
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);
        }
    }
    private bool yay = true;
    void changeDirection()
    {
        if(!yay)
        {
            yay = true;
            customGravity.force = new Vector2(40, 0);
            rb.AddForce(new Vector2(100f, 0));
        }
        else
        {
            yay = false;
            customGravity.force = new Vector2(-40, 0);
            rb.AddForce(new Vector2(-100f, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("Wall"))
        {
            isDead = true;
            deadAnimation.SetActive(true);
            customGravity.force = new Vector2(0, 0);
            rb.velocity = new Vector2(0, 0);
            WLScoreScript.playerDied();
            StartCoroutine(Wait());
        }
    }
    public void AliveAgain()
    {
        restartButton.SetActive(false);
        WLScoreScript.playerAlive();
        WLDeadScript.ResetScale();
        transform.position = new Vector3(0, 0 + 0.15f, 0);
        isDead = false;
        line.gameObject.SetActive(true);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        restartButton.SetActive(true);
        line.gameObject.SetActive(false);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }
    }
}
