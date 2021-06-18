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
    private float screenBottom;
    private float screenTop;

    [SerializeField] LayerMask _layerMask;
    public float chaseSpeed = 3.0f;
    public float scrollSpeed = -1.0f;
    public bool chasing = true;

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

        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y + transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y * -1 - transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing)
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
        else
        {
            rb.velocity = new Vector2(0, scrollSpeed * chaseSpeed);
        }

        if (transform.position.y < screenBottom)
        {
            Destroy(gameObject);
        }

    }


    bool isPlayerVisible()
    {
        if (transform.position.y > screenTop)
        {
            return false;
        }

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


    public void setSatisfied()
    {
        chasing = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
