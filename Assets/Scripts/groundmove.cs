using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundmove : MonoBehaviour

{

    Rigidbody2D body;
    float y = 0f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        y = transform.position.y; 
        speed = 50f;
        body.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {   
        float y2 = transform.position.y; 
        if (y2 <= -10) {
            transform.position = new Vector3(transform.position.x, 9.85f, 0);
        }
    }
}
