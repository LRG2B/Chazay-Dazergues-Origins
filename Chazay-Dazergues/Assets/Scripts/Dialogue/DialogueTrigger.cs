using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private bool IsAllow;
    public Dialogue dialogue;

    private bool Activated;

    void Start()
    {
        IsAllow = false;
        Activated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && IsAllow && !Activated)
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

    public void SetActivated(bool Activation)
    {
        Activated = Activation;
    }
}
