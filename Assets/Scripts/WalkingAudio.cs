using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAudio : MonoBehaviour
{
    public AudioClip[] footStepAudio_Gravel;
    public AudioClip[] footStepAudio_Grass;
    private AudioSource audioSource;
    public float timer = 0f;
    public float footStepSpeed;
    private ThirdPersonMovement player;
    private int randomFootStep;
    public int footMaterialID;

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
            if (footMaterialID == 0)
            {
                if (timer > footStepSpeed)
                {
                    randomFootStep = Random.Range(0, footStepAudio_Gravel.Length);
                    audioSource.clip = footStepAudio_Gravel[randomFootStep];
                    audioSource.Play();
                    timer = 0f;
                }
            }

            else if (footMaterialID == 1)
            {
                if (timer > footStepSpeed)
                {
                    randomFootStep = Random.Range(0, footStepAudio_Grass.Length);
                    audioSource.clip = footStepAudio_Grass[randomFootStep];
                    audioSource.Play();
                    timer = 0f;
                }
            }
        }

        else if (player.isMoving == false || player.isGrounded == false)
        {
            audioSource.Stop();
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}