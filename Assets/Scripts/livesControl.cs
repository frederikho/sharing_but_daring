using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class livesControl : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI textMeshPro;
    [SerializeField]int lives = 5;
    public int livesleft = 5;
   

    // Update is called once per frame
    void Update()
    {
    if (livesleft != lives) {
        textMeshPro.text = "x "+livesleft.ToString();
        lives = livesleft;
    }   
    }
}
