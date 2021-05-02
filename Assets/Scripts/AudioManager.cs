using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource field;
	public AudioSource battle;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider other) {
		if (battle.isPlaying) {
			return;
		}
		
		if (other.tag == "Player") {
			field.Stop();
			battle.Play();
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		if (field.isPlaying) {
			return;
		}
		
		if (other.tag == "Player") {
			battle.Stop();
			field.Play();
		}
	}
}
