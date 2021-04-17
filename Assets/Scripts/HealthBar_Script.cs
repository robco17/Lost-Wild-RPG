using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This code was used from https://www.youtube.com/watch?v=NE5cAlCRgzo

public class HealthBar_Script : MonoBehaviour
{
    public Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    ThirdPersonMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
