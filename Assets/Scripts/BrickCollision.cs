using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    Rigidbody2D body;
    float y = 0f;
    public float speed; // should read speed from groundmove
    [SerializeField] private GameObject destructionParticles;

    
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

        body.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
        //brick.SetActive(false);
        //gameObject.SetActive(false);
        //DestroyImmediate(clone);    // <- Correct object to destroy

        float y2 = transform.position.y; 
        if (y2 <= -10) {
            transform.position = new Vector3(transform.position.x, 9.85f, 0);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.SetActive(false);
        //Destroy(collision.collider.gameObject);
        if (collision.collider.name == "player 1"  ||   collision.collider.name == "player 2")
        {
            // if (has hammer == TRUE )
            Destroy(gameObject);
            Debug.Log("Destroyed");
            // play animation here
            
        }
        else
        {
            Debug.Log(collision.collider.name);
        }
        
    }

}
