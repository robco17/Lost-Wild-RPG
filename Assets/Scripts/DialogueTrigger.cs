using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

// Inactive script; DO NOT USE
// Might come in handy later though.

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialogue(string npc)
    {
        if (npc.Equals("Victor"))
        {
            Fungus.Flowchart.BroadcastFungusMessage("Victor Start");
        }
        else if (npc.Equals("Claire"))
        {
            Fungus.Flowchart.BroadcastFungusMessage("Claire Start");
        }
        else if (npc.Equals("Grandma"))
        {
            Fungus.Flowchart.BroadcastFungusMessage("Grandma Start");
        }
        else if (npc.Equals("Simon"))
        {
            Fungus.Flowchart.BroadcastFungusMessage("Simon Start");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue(gameObject.tag);
        }
    }
}
