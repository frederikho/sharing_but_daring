using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bootsUI : MonoBehaviour
{   
    private int ownnerPlayer = 1;
    float x = 0f;
    float y = 0f;
    public float offset = 2;
    public float speed = 200f;
    private bool startedMoving = false;
    Rigidbody2D body;
    public string p1button = "j";
    public string p2button = "1";
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        float x = transform.position.x;
        float y = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(p1button) && ownnerPlayer == 1 && startedMoving == false){
            body.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
            startedMoving = true;
        }
        if (Input.GetKeyDown(p2button) && ownnerPlayer == 2 && startedMoving == false){
            body.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
            startedMoving = true;
        }
        if (startedMoving == true && ownnerPlayer == 1 && transform.position.x <= x - offset ) {
            body.velocity = new Vector2(0, 0);
            startedMoving = false; 
            ownnerPlayer  = 2;  
        }
        if (startedMoving == true && ownnerPlayer == 2 && transform.position.x >= x + offset ) {
            body.velocity = new Vector2(0, 0);
            startedMoving = false; 
            ownnerPlayer  = 1;
            
        }
    }
}
