using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject backgroundMusic;
    void Start()
    {
        backgroundMusic = GameObject.Find("Background Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        // making button transparent to show the other button
        if (GetComponent<SpriteRenderer>().color != new Color(1.0f, 1.0f, 1.0f, 0.0f))
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            backgroundMusic.GetComponent<AudioSource>().mute = true;
        }
        else 
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            backgroundMusic.GetComponent<AudioSource>().mute = false;
        }
        
        

    }
}
