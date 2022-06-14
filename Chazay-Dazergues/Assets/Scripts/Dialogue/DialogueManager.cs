using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<Sentences> sentences;

    private float speed;
    private float jump;

    void Start()
    {
        sentences = new Queue<Sentences>();
        speed = GameObject.Find("HeroKnight").GetComponent<Mouvement>().Speed;
        jump = GameObject.Find("HeroKnight").GetComponent<Mouvement>().jump_power;
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
        GameObject.Find("HeroKnight").GetComponent<Mouvement>().Speed = 0f;
        GameObject.Find("HeroKnight").GetComponent<Mouvement>().jump_power = 0f;
        GameObject.Find("HeroKnight").GetComponent<Animator>().SetBool("CanMove", false);
        GameObject.Find("HeroKnight").GetComponent<Animator>().SetBool("CanAttack", false);
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.sentences[0].Name;

        sentences.Clear();

        foreach (Sentences sentence in dialogue.sentences)
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

        Sentences sentence = sentences.Dequeue();
        nameText.text = sentence.Name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.Sentence));
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

        GameObject.Find("HeroKnight").GetComponent<Mouvement>().Speed = speed;
        GameObject.Find("HeroKnight").GetComponent<Mouvement>().jump_power = jump;
        GameObject.Find("HeroKnight").GetComponent<Animator>().SetBool("CanMove", true);
    }
}