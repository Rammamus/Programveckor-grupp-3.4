using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{ //g�r s� att textrutornas minimum p� rader �r tre och maximum �r 10
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    //skapar en array som heter sentences
}

