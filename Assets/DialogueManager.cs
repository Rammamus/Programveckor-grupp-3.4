using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject Uppgradepanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    private Queue<string> sentences;
    public bool inconversation = false;
    public GameObject panel;
    public GameObject spelare;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        panel.SetActive(true);
        inconversation = true;
        Time.timeScale = 0f;
        Debug.Log("Startar konversation med " + dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextScentence();
    }
    public void DisplayNextScentence()
    {
        if (sentences.Count == 0)
        {
            inconversation = false;
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        
            StartCoroutine(TypeSentence(sentence));
        
        
    }
    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.07f);
        }
    }
    void EndDialogue()
    {
        Debug.Log("Slut på konversationen.");
        
        Time.timeScale = 1f;
        if (cooldown <= Time.time)
        {
            Uppgradepanel.SetActive(true);
            cooldown = Time.time + 100f;
        }
        panel.SetActive(false);
    }
}
