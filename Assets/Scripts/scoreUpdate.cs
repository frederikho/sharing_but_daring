using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUpdate : MonoBehaviour
{
    
     
    
    public int score = 0;
    public float timer = 0.4f;
    public float actualtimer;
    public int increment = 50;
    [SerializeField]TextMeshProUGUI textMeshPro;
    void Start() {
        actualtimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        actualtimer = actualtimer-1*Time.fixedDeltaTime;
        if (actualtimer <= 0) {
            score = score + increment;
            textMeshPro.text = score.ToString();
            actualtimer = timer;
        }
    }
}
