using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public float speed = -10.0f;
    private Rigidbody2D rb;
    private bool canSummonNewElement = true;
    public GameObject prefab;

    public float respawnPoint = 15;
    public float destructionPoint = -15;
    public float triggerPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, speed);
        if (canSummonNewElement && transform.position.y <= triggerPoint)
        {
            summonNewElement();
        }

        if (transform.position.y <= destructionPoint)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }

    void summonNewElement()
    {
        Instantiate(prefab, new Vector2(-6.5f, respawnPoint), Quaternion.identity);
        canSummonNewElement = false;
    }
}
