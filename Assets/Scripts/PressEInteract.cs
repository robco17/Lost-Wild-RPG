using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressEInteract : MonoBehaviour
{
    public GameObject eButton;
    private GameObject player;
    float distance;
    bool isTalking = false;
    private ThirdPersonMovement thirdPersonMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        thirdPersonMovement = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2.5f)
        {
            // Triggers the interact button to appear.
            if (isTalking == false)
            {
                eButton.SetActive(true);
            }
            else if (isTalking == true)
            {
                eButton.SetActive(false);
            }
        }
    }
}
