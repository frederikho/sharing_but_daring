using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public float backgroundMusicInitVolume;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusicInitVolume = GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
