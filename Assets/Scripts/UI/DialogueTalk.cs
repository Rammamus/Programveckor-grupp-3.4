using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{ //gör så att textrutornas minimum på rader är tre och maximum är 10
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    //skapar en array som heter sentences
}

