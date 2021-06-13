using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private string playerName = "Player1";
    private Rigidbody2D rb;

    [SerializeField] LayerMask _layerMask;
    public float chaseSpeed = 3.0f;
    public float scrollSpeed = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(playerName).transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerVisible())
        {
            GetComponent<SpriteRenderer>().color = Color.red;

            Vector2 playerDirection = player.position - transform.position;
            playerDirection.Normalize();
            playerDirection *= chaseSpeed;
            rb.velocity = playerDirection + new Vector2(0, scrollSpeed);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            rb.velocity = new Vector2(0, scrollSpeed);
        }

    }


    bool isPlayerVisible()
    {
        Vector2 playerDirection = player.position - transform.position;
        Debug.DrawLine(transform.position, player.position, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, 1000f, _layerMask);
        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.GetComponent<p1Controller>().speed);
            if (hit.transform.name == playerName)
            {
                return true;
            }
        }

        return false;
    }
}
