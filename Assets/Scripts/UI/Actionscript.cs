using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionscript : MonoBehaviour
{
    public GameObject Uppgradepanel;
    // Update is called once per frame
    public void Start()
    {
        Uppgradepanel.SetActive(false);
    }
    public void Action()
    {
        if (gameObject.CompareTag("goldgoldgold"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Uppgradepanel.SetActive(true);
            }
        }
    }
}
