using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAudio : MonoBehaviour
{
    public AudioClip footStepAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
            audio.clip = footStepAudio;
            audio.Play();
        }
    }
}
