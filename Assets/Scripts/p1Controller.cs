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
    public float limiter;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (PlayerNumberControls == 1) {
            AxisName = "Player1";
        }
        if (PlayerNumberControls == 2) {
            AxisName = "Player2";
        }

        
    }

    // Update is called once per frame
    void Update()
    {
    leftright = Input.GetAxisRaw(AxisName+"Horizontal") * speed;
    updown = Input.GetAxisRaw(AxisName+"Vertical") * speed; 
        
    }
   void FixedUpdate(){
    if (leftright != 0 && updown != 0){
            leftright *= limiter;
            updown  *= limiter;
        }
    if (1 == 1) {
        
    }
    body.velocity = new Vector2(leftright * Time.fixedDeltaTime, updown * Time.fixedDeltaTime);
    }
}
