using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bootsUI : MonoBehaviour
{   
       
    public int ownnerPlayer = 2;
    public float x = 0f;
    public float y = 0f;
    public float offset = 2;
    public float speed = 200f;
    private bool startedMoving = false;
    Rigidbody2D body;
    public string p1button = "j";
    public string p2button = "1";
    private bool wasjustpressed1 = false;
    private bool wasjustpressed2 = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        y = transform.position.y; 
        ownnerPlayer = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        float x2 = transform.position.x;
        float y2 = transform.position.y; 
        if (Input.GetKeyUp(p1button)) {
            wasjustpressed1 = false;
        }
        if (Input.GetKeyUp(p2button)) {
            wasjustpressed2 = false;
        }

        if (startedMoving == true && ownnerPlayer == 1 && x2 <= x - offset ) {
            body.velocity = new Vector2(0, 0);
            transform.position = new Vector3(x-offset, y, 0);
            
            startedMoving = false; 
            ownnerPlayer  = 1;  
        }
        if (startedMoving == true && ownnerPlayer == 2 && x2 >= x) {
            body.velocity = new Vector2(0, 0);
            transform.position = new Vector3(x, y, 0);
            
            startedMoving = false; 
            ownnerPlayer  = 2;
            
        }

        if (Input.GetKeyDown(p1button) && ownnerPlayer == 1 && startedMoving == false && wasjustpressed1 == false){
            body.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
            startedMoving = true;
            wasjustpressed1 = true;
        }
        if (Input.GetKeyDown(p2button) && ownnerPlayer == 2 && startedMoving == false && wasjustpressed2 == false){
            body.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
            startedMoving = true;
            wasjustpressed2 = true;
        }

        
    }


}


