using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    public DialogueManager dia;
    // Start is called before the first frame update
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && dia.inconversation)
        {
            dia.DisplayNextScentence();
        }

    }
}
