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
    public bool slowed; 
    
    public float slowFactor;
    public float limiter;
    Collider2D playerCollider;
    private GameObject bootUI;
    
    Camera cam;
    private float camHeight;
    private float camWidth;
    private float camSize;
    private float camAspect;

    private bool playerHitBottom;

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
        playerCollider = GetComponent<Collider2D>();
        
        // Camera stuff
        cam = Camera.main;
        camSize = cam.orthographicSize;
        camHeight = camSize;
        camWidth = camSize * 2;
        
        slowFactor = 0.5f;
        slowed = false;
        bootUI = GameObject.Find("BootsUI");
    }

    // Update is called once per frame
    void Update()
    {
        leftright = Input.GetAxisRaw(AxisName+"Horizontal") * speed;
        updown = Input.GetAxisRaw(AxisName+"Vertical") * speed;


        // playewr is slowed if true
        if (slowed && bootUI.GetComponent<bootsUI>().ownnerPlayer != PlayerNumberControls)
        {
            leftright *= slowFactor;
            updown *= slowFactor;
        }

        if (transform.position.y < (cam.transform.position.y - camHeight))
        {
            //Decrease Life by one

            //

            //playerCollider.enabled = false; // besser: Change Collision Layer

            //Debug.Log(camHeight.ToString() + camWidth.ToString());
        }
        resetPlayerCollision();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.name == "Main Camera" && collision.collider.gameObject.layer == 3) // 3 is Layer Collision with Player. Maybe change that. 
        {
            Debug.Log("Colliding with Camera.");
            playerCollider.enabled = false; // besser: Change Collision Layer


            Invoke("resetPlayerCollision", 4.0f);
            GetComponent<SpriteRenderer>().color = Color.green;
            
            
            Canvas = GameObject.Find("Text_(TMP)lives");
            Canvas.GetComponent<livesControl>().livesleft = Canvas.GetComponent<livesControl>().livesleft - 1;
            
            

        }
        else if (collision.collider.name == "catbat" && collision.collider.gameObject.layer == 6)
        {
            playerCollider.enabled = false; // besser: Change Collision Layer
            
            Canvas = GameObject.Find("Text_(TMP)lives");
            Canvas.GetComponent<livesControl>().livesleft = Canvas.GetComponent<livesControl>().livesleft - 1;
        }
        else 
        {
            Debug.Log(collision.collider.gameObject.layer);
        }

        
    }

    public void resetPlayerCollision()
    {
        playerCollider.enabled = true;
    }


   void FixedUpdate(){
    if (leftright != 0 && updown != 0){
            leftright *= limiter;
            updown  *= limiter;
        }
    body.velocity = new Vector2(leftright * Time.fixedDeltaTime, updown * Time.fixedDeltaTime);
    }
}
