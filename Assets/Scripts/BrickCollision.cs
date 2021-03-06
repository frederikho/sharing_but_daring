using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    Rigidbody2D body;
    GameObject HammerUI;
    bootsUI HammerUIScript;
    public float speed; // should read speed from groundmove
    public AudioClip destroyBrickSound;
    [SerializeField] private GameObject destructionParticles;

    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = destroyBrickSound;
        /*
        y = transform.position.y; 
        speed = 50f;
        body.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);        
        */
    }

    // Update is called once per frame
    void Update()
    {
        
        //body.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
        
        //float y2 = transform.position.y; 
        //if (y2 <= -10) {
        //    transform.position = new Vector3(transform.position.x, 9.85f, 0);
        //}
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        HammerUI = GameObject.Find ("HammerUI");
        //Debug.Log(HammerUI.GetComponent<bootsUI>().ownnerPlayer);
        //collision.gameObject.SetActive(false);
        //Destroy(collision.collider.gameObject);
        
        if ((collision.collider.name == "Player1"  &&  HammerUI.GetComponent<bootsUI>().ownnerPlayer == 1) || 
            (collision.collider.name == "Player2" && HammerUI.GetComponent<bootsUI>().ownnerPlayer == 2))
        {
            if (1 == 1){
                GetComponent<AudioSource>().Play();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                //Destroy(gameObject);
                // play animation here

            }
            
        }
        else
        {
            //Debug.Log(collision.collider.name);
        }
        
    }

}
