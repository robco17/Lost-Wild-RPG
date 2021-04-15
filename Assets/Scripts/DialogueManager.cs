using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This code was used from https://www.youtube.com/watch?v=WBH4LecZCwE

public class DialogueManager : MonoBehaviour
{
    public NPC npc;
    bool isTalking = false;
    float distance;
    float curResponseTracker = 0;
    public GameObject player;
    public GameObject eButton;
    public GameObject dialogueUI;
    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;
    private ThirdPersonMovement thirdPersonMovement;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        thirdPersonMovement = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2.5f)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                curResponseTracker++;
                if (curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if (curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            /* Triggers the interact button to appear.
            if (isTalking == false)
            {
                if (!eButton.active)
                {
                    eButton.SetActive(true);
                }
                
                // Triggers dialogue
                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
                {
                    StartConversation();
                }
            }*/
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
        thirdPersonMovement.canMove = false;
        //thirdPersonMovement.speed = 0f;
        //thirdPersonMovement.jumpHeight = 0f;
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        thirdPersonMovement.canMove = true;
        //thirdPersonMovement.speed = 7f;
        //thirdPersonMovement.jumpHeight = 2f;
    }
}