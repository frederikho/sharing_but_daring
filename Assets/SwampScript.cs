using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        p1Controller player = collider.GetComponent<p1Controller>();
        Debug.Log("Swamp Enter: " + player);
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        p1Controller player = collider.GetComponent<p1Controller>();
        Debug.Log("Swamp Leave: " + player);
    }
}
