using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAudio : MonoBehaviour
{
    public AudioClip footStepAudio;
    private AudioSource audioSource;
    public float timer = 0f;
    public float footStepSpeed;
    private ThirdPersonMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        //footStepSpeed += (audioSource.clip.length + 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isMoving && player.isGrounded)
        {
            if (timer > footStepSpeed)
            {
                audioSource.Play();
                timer = 0f;
            }
        }
        else if (player.isMoving == false || player.isGrounded == false)
        {
            audioSource.Stop();
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
            audio.clip = footStepAudio;
            audio.Play();
        }
    }*/
}