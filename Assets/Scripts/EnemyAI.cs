using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private string playerName = "Player";
    private Rigidbody2D rb;
    private GameObject CloakUI;
    private int playerNumber = 1;

    [SerializeField] LayerMask _layerMask;
    public float chaseSpeed = 3.0f;
    public float scrollSpeed = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x >= 0)
        {
            playerNumber = 2;
        }
        else
        {
            playerNumber = 1;
        }

        playerName += playerNumber;
        player = GameObject.Find(playerName).transform;
        rb = this.GetComponent<Rigidbody2D>();
        CloakUI = GameObject.Find("CloakUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerVisible())
        {
            // GetComponent<SpriteRenderer>().color = Color.red;

            Vector2 playerDirection = player.position - transform.position;
            playerDirection.Normalize();
            playerDirection *= chaseSpeed;
            rb.velocity = playerDirection + new Vector2(0, scrollSpeed);
        }
        else
        {
            // GetComponent<SpriteRenderer>().color = Color.green;
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
            if (hit.transform.name == playerName && CloakUI.GetComponent<bootsUI>().ownnerPlayer != playerNumber)
            {
                return true;
            }
        }

        return false;
    }
}
