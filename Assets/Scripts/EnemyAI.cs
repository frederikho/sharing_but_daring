using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private string playerName = "player 1";
    private Rigidbody2D rb;
    
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
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        Vector2 playerDirection = player.position - transform.position;
        playerDirection.Normalize();
        rb.velocity = playerDirection;

    }


    bool isPlayerVisible()
    {
        Vector2 playerDirection = player.position - transform.position;
        Debug.DrawLine(transform.position, player.position, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, 1000f);
        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.transform.name);
            if (hit.transform.name == playerName)
            {
                return true;
            }
        }

        return false;
    }
}
