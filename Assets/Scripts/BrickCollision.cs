using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    Rigidbody2D body;
    GameObject HammerUI;
    bootsUI HammerUIScript;
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
        HammerUI = GameObject.Find ("HammerUI");
        Debug.Log(HammerUI.GetComponent<bootsUI>().ownnerPlayer);
        //collision.gameObject.SetActive(false);
        //Destroy(collision.collider.gameObject);
        if ((collision.collider.name == "player 1"  &&  HammerUI.GetComponent<bootsUI>().ownnerPlayer == 1) || 
            (collision.collider.name == "player 2" && HammerUI.GetComponent<bootsUI>().ownnerPlayer == 2))
        {
            if (1 == 1){
                Destroy(gameObject);
                
                // play animation here
            
            }
            
        }
        else
        {
            //Debug.Log(collision.collider.name);
        }
        
    }

}
