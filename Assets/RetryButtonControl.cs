using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RetryButtonControl : MonoBehaviour
{
    private bool wasJustPressed = false;
    private bool timerRunning = false;
    public float timer = 4.0f;
    public string goalSceneName = "Jan2"; // scene that you restart in if r is pressed
    [SerializeField]TextMeshProUGUI textMeshPro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && wasJustPressed == false){
            wasJustPressed = true;
            timerRunning = true;
        }
        if (timerRunning) {
            int convertedTimer = (int)(timer % 60);
            textMeshPro.text = convertedTimer.ToString();
            timer -= Time.deltaTime;
        }

        if (timer <= 0) {
            SceneManager.LoadScene(goalSceneName);
        }
    
    }
}
