using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    Rigidbody2D body;
    
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //brick = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //body.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
        //brick.SetActive(false);
        //gameObject.SetActive(false);
        //DestroyImmediate(clone);    // <- Correct object to destroy
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }

}
