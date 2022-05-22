using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public Text instructionText;
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            EndInstruction();
        }
    }

    public void StartInstruction(Instruction instruction)
    {
        animator.SetBool("IsOpen", true);
        instructionText.text = instruction.name;
    }

    public void EndInstruction()
    {
        animator.SetBool("IsOpen", false);
    }
}
