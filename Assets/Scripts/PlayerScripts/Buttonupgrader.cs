using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonupgrader : MonoBehaviour
{
    public string Upgradepanel;
    public string Playername;
    public GameObject player;
    public GameObject panel;
    public void Update()
    {
        panel = GameObject.Find(Upgradepanel);
        player = GameObject.Find(Playername);
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
        PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
        playerCombat.maxHP += 2;
        HealthBarScript healthBar = FindObjectOfType<HealthBarScript>();
        healthBar.DrawHearts();
        panel.SetActive(false);
    }
    public void maxhp2()
    {
        if (player != null)
        {
            PlayerCombat playerCombat = player.GetComponent<PlayerCombat>(); // Use GetComponent
            if (playerCombat != null)
            {
                playerCombat.maxHP += 4;

                HealthBarScript healthBar = FindObjectOfType<HealthBarScript>(); // Use FindObjectOfType
                if (healthBar != null)
                {
                    healthBar.DrawHearts();
                }
                else
                {
                    Debug.LogWarning("HealthBarScript not found in the scene.");
                }
            }
            else
            {
                Debug.LogWarning("PlayerCombat component not found on player: " + Playername);
            }
            panel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Player with name " + Playername + " not found.");
        }
    }
    public void maxhp3()
    {
        PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
        playerCombat.maxHP += 6;
        HealthBarScript healthBar = FindObjectOfType<HealthBarScript>();
        healthBar.DrawHearts();
        panel.SetActive(false);
    }
}
