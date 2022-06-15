using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruction_trigger_femme : MonoBehaviour
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
        FindObjectOfType<Attack>().UpgradeDamage(10);
    }

    public void TriggerEndInstruction()
    {
        FindObjectOfType<InstructionManager>().EndInstruction();
    }
}
