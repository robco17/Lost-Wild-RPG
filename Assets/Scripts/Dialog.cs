using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This code was used from https://www.youtube.com/watch?v=f-oSXg6_AMQ

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public Text npcName;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject dialogueUI;
    public GameObject continueButton;
    private ThirdPersonMovement thirdPersonMovement;
    bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonMovement = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        // Types the text out letter by letter; adjustable typing speeds.
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // When you hit the continue button, it types the next sentence.
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueUI.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        StartCoroutine(Type());
    }
    /*
    public void StartConversation()
    {
        isTalking = true;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        thirdPersonMovement.canMove = false;
        //thirdPersonMovement.speed = 0f;
        //thirdPersonMovement.jumpHeight = 0f;
    }

    public void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        thirdPersonMovement.canMove = true;
        //thirdPersonMovement.speed = 7f;
        //thirdPersonMovement.jumpHeight = 2f;
    }*/
}
