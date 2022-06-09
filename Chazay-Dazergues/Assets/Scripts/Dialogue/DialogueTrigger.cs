using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private bool IsAllow;
    public Dialogue dialogue;

    void Start()
    {
        IsAllow = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && IsAllow)
        {
            TriggerDialogue();
            IsAllow = false;
        }
    }

    void OnTriggerEnter2D()
    {
        IsAllow = true;
    }

    void OnTriggerExit2D()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        IsAllow = false;
    }

    public void TriggerEndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
