using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sentences[] sentences;
}

[System.Serializable]
public class Sentences
{
    public string Name;
    [TextArea (3,10)]
    public string Sentence;
}