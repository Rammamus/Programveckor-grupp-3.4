using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] public GameObject interractText;
    public Talker dial;
    // Update is called once per frame

    private void Start()
    {
        Talker talk = GetComponent<Talker>();
        interractText.SetActive(false);
    }

    public void Update()
    {
        Vector3 newposition = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newposition, 1.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.GetComponent("Actionscript"))
            {
                //Debug.Log("Triggered by an object with the goldgoldgold tag!");
                interractText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dial.Triggerdialogue();
                }
                //collider.GetComponent<Actionscript>().Action();
            }
            else
            {
                interractText.SetActive(false);
            }
        }
    }
}
