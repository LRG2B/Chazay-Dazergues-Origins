using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    private float speed;
    private float jump;

    void Start()
    {
        sentences = new Queue<string>();
        speed = GameObject.Find("Player").GetComponent<Player_mouvement>().Speed;
        //jump = GameObject.Find("Player").GetComponent<Player_mouvement>().jumpPower;
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameObject.Find("Player").GetComponent<Player_mouvement>().Speed = 0f;
        //GameObject.Find("Player").GetComponent<PlayerController>().jumpPower = 0f;
        GameObject.Find("Player").GetComponent<Animator>().SetBool("CanMove", false);
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        GameObject.Find("Player").GetComponent<Player_mouvement>().Speed = speed;
        //GameObject.Find("Player").GetComponent<Player_mouvement>().jumpPower = jump;
        GameObject.Find("Player").GetComponent<Animator>().SetBool("CanMove", true);
    }
}