using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionTrigger : MonoBehaviour
{
    public Instruction instruction;

    void Start() { }
    void Update() { }

    void OnTriggerEnter2D()
    {
        TriggerInstruction();
    }

    void OnTriggerExit2D()
    {
        TriggerEndInstruction();
    }

    public void TriggerInstruction()
    {
        FindObjectOfType<InstructionManager>().StartInstruction(instruction);
    }

    public void TriggerEndInstruction()
    {
        FindObjectOfType<InstructionManager>().EndInstruction();
    }
}
