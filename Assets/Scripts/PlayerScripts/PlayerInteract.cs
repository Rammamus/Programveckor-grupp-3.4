using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 newposition = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newposition, 1.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.GetComponent("Actionscript"))
            {
                Debug.Log("Triggered by an object with the goldgoldgold tag!");
                collider.GetComponent<Actionscript>().Action();

            }
        }
    }
}
