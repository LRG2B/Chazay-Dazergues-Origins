using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruction_trigger_boss : MonoBehaviour
{
    public Instruction instruction;

    void Start() { }
    void Update() { }

    void OnTriggerEnter2D()
    {
        if (FindObjectOfType<boss_control>().Isdead())
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
