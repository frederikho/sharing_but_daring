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
    private GameObject backgroundMusic;
    [SerializeField]TextMeshProUGUI textMeshPro;
    void Start()
    {
        backgroundMusic = GameObject.Find("Background Music");
        
        

        StartCoroutine(FadeAudioSource.StartFade(backgroundMusic.GetComponent<AudioSource>(), 3.0f, 0.0f));
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
            backgroundMusic.GetComponent<AudioSource>().Play();
            float backgroundMusicInitVolume = backgroundMusic.GetComponent<AudioScript>().backgroundMusicInitVolume;   
            backgroundMusic.GetComponent<AudioSource>().volume = backgroundMusicInitVolume;
            
        }
    
    }

    public static class FadeAudioSource 
    {
        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }
}
