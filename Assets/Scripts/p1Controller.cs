using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Controller : MonoBehaviour
{
    public int PlayerNumberControls = 1; // determines weather player1 or player2 controls are used
    public float leftright = 0f;
    public float updown = 0f;
    private string AxisName;   // Start is called before the first frame update
    Rigidbody2D body;
    public float speed;

    // the speed at which the map scrolls by
    public float mapSpeed = 1.0f;

    // parameters for player slowing down when hitting swamp
    public int slowed = 0;
    public float slowDragBack = 0f;     // the amount of velocity that the player is dragged backwards by
    public float slowFactor = 0.5f;
    public float limiter;
    private GameObject bootUI;

    // if this is true, player will take damage once invulnerability ends
    public bool playerDamaged = false;
    public float invulnerabilityTime = 5.0f;
    private float invulnerabilityLeft = 0;

    BoxCollider2D playerCollider;
    SpriteRenderer spriteRenderer;
    
    Camera cam;
    private float camHeight;
    private float camWidth;
    private float camSize;
    private float camAspect;

    private bool playerHitBottom;

    // variables for screen clamping
    public float playerOverhang;
    public float bottomOutOfScreen;
    private Vector3 screenBounds;
    private float playerWidth;
    private float playerHeight;

    private GameObject Canvas;
    public int livesleft;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (PlayerNumberControls == 1) {
            AxisName = "Player1";
        }
        if (PlayerNumberControls == 2) {
            AxisName = "Player2";
        }
        
        // Camera stuff
        cam = Camera.main;
        camSize = cam.orthographicSize;
        camHeight = camSize;
        camWidth = camSize * 2;
        
        slowed = 0;
        bootUI = GameObject.Find("BootsUI");

        // initiate settings for screen clamping
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2 - playerOverhang;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        leftright = Input.GetAxisRaw(AxisName+"Horizontal") * speed;
        updown = Input.GetAxisRaw(AxisName+"Vertical") * speed;


        // player is slowed if true
        if (slowed > 0 && bootUI.GetComponent<bootsUI>().ownnerPlayer != PlayerNumberControls)
        {
            leftright *= slowFactor;
            updown *= slowFactor;
            updown -= mapSpeed * (1 - slowFactor);  // this here just slows the player based on the map scroll speed
        }


        spriteRenderer.color = Color.white;
        playerCollider.enabled = true;
        if (invulnerabilityLeft > 0)
        {
            if (invulnerabilityLeft % 1 > 0.5f)
            {
                spriteRenderer.color = Color.red;
            }
            playerCollider.enabled = false;
            invulnerabilityLeft -= Time.deltaTime;
        }
        else if (playerDamaged)
        {
            damagePlayer();
            playerCollider.enabled = false;
            invulnerabilityLeft = invulnerabilityTime;
        }

        playerDamaged = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 8) // I wrote dirty bullshit that will cause bugs lmao
        {
            collision.collider.GetComponent<EnemyAI>().setSatisfied();
            playerDamaged = true;
        }
    }


    void FixedUpdate(){
        if (leftright != 0 && updown != 0){
            leftright *= limiter;
            updown  *= limiter;
        }
        body.velocity = new Vector2(leftright * Time.fixedDeltaTime, updown * Time.fixedDeltaTime);
    }


    void LateUpdate()
    {
        // clamping player position to be onscreen at all times
        Vector3 playerPos = transform.position;
        if (PlayerNumberControls == 1)
        {
            playerPos.x = Mathf.Clamp(playerPos.x, screenBounds.x * -1 + playerWidth, -playerWidth);
        }
        else
        {
            playerPos.x = Mathf.Clamp(playerPos.x, playerWidth, screenBounds.x - playerWidth);
        }

        if (playerPos.y <= screenBounds.y * -1 + playerHeight - bottomOutOfScreen)
        {
            playerDamaged = true;
        }
        playerPos.y = Mathf.Clamp(playerPos.y, screenBounds.y * -1 + playerHeight - bottomOutOfScreen, screenBounds.y - playerHeight);
        transform.position = playerPos;
    }


    void damagePlayer()
    {
        Canvas = GameObject.Find("Text_(TMP)lives");
        Canvas.GetComponent<livesControl>().livesleft = Canvas.GetComponent<livesControl>().livesleft - 1;
    }
}
