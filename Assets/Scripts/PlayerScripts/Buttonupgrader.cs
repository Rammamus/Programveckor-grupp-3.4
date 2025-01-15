using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonupgrader : MonoBehaviour
{
    public string Upgradepanel;
    public GameObject player;
    public GameObject panel;
    void Update()
    {
        panel = GameObject.Find(Upgradepanel);
        
    }
    public void power1()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
          
    }
    public void power2()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void power3()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void haste1()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void haste2()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void haste3()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void speed1()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void speed2()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void speed3()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log(Upgradepanel + "has been deactivated.");
        }
        else
        {
            Debug.LogWarning("Object with name " + Upgradepanel + " not found.");
        }
    }
    public void maxhp1()
    {
        PlayerCombat.FindAnyObjectByType<PlayerCombat>().maxHP += 2;
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        panel.SetActive(false);
    }
    public void maxhp2()
    {
        PlayerCombat.FindAnyObjectByType<PlayerCombat>().maxHP += 4;
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        panel.SetActive(false);
    }
    public void maxhp3()
    {
        PlayerCombat.FindAnyObjectByType<PlayerCombat>().maxHP += 6;
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        panel.SetActive(false);
    }
}
