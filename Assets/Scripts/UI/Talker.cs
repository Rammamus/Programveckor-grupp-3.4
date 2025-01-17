using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    public Dialogue dialogue;
    public AudioClip[] talkSFX;

    public void Triggerdialogue()
    {


        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}
