using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Buttonupgrader : MonoBehaviour
{
    public string Upgradepanel;
    public string Playername;
    private GameObject player;
    private GameObject panel;
    public string Replacepanel;
    public string upgradeButton1;
    public string upgradeButton2;
    public string upgradeButton3;
    private PlayerUppgrades playerUppgrade;
    private int indexToReplace;
    private StatBonus newBonus;
    public GameObject replacepanel1;
    private GameObject button1;
    private GameObject button2;
    private GameObject button3;



    public void Update()
    {
        panel = GameObject.Find(Upgradepanel);
        player = GameObject.Find(Playername);
        replacepanel1 = GameObject.Find(Replacepanel);
        button1 = GameObject.Find(upgradeButton1);
        button2 = GameObject.Find(upgradeButton1);
        button3 = GameObject.Find(upgradeButton1);
        playerUppgrade = player.GetComponent<PlayerUppgrades>();


        if (panel == null) Debug.LogError("Panel not found: " + Upgradepanel);
        if (player == null) Debug.LogError("Player not found: " + Playername);
        if (replacepanel1 == null) Debug.LogError("Replacement panel not found: " + Replacepanel);
        if (button1 == null) Debug.LogError("Button 1 not found: " + upgradeButton1);
        if (button2 == null) Debug.LogError("Button 2 not found: " + upgradeButton2);
        if (button3 == null) Debug.LogError("Button 3 not found: " + upgradeButton3);
        if (playerUppgrade == null) Debug.LogError("PlayerUppgrades component not found on player.");
    }
    public void AddStatBonus(string bonusName, float bonusValue, BonusType bonusType)
    {
        PlayerUppgrades playerUppgrade = player.GetComponent<PlayerUppgrades>();
        int pmax = PlayerUppgrades.maxSlots;
        Debug.Log("Attempting to add bonus: " + bonusName); // Debug log

        
        StatBonus newBonus = new StatBonus(bonusName, bonusValue, bonusType);

        if (playerUppgrade.statBonuses.Count < pmax)
        {
            playerUppgrade.statBonuses.Add(newBonus);
            Debug.Log(bonusName + " added. Total bonuses: " + playerUppgrade.statBonuses.Count);
            ApplyBonusToPlayer(newBonus);
        }
        else
        {
            // När alla slots är fulla så försöker den replacea
            playerUppgrade.Openreplacementpanel();
            //panel.SetActive(false);

            ShowReplacementMenu();
           
        }
    }
    public void ShowReplacementMenu()
    {
        if (playerUppgrade == null)
        {
            Debug.LogError("playerUppgrade is null! Make sure the PlayerUppgrades component is attached to the player.");
            return; // Exit the method if playerUppgrade is null
        }
        if (playerUppgrade.statBonuses.Count > 0)
        {
            button1.GetComponentInChildren<Text>().text = playerUppgrade.statBonuses[0].bonusName;
            button1.gameObject.SetActive(true);
        }
        else
        {
            button1.gameObject.SetActive(false);
        }

        if (playerUppgrade.statBonuses.Count > 1)
        {
            button2.GetComponentInChildren<Text>().text = playerUppgrade.statBonuses[1].bonusName;
            button2.gameObject.SetActive(true);
        }
        else
        {
            button2.gameObject.SetActive(false);
        }

        if (playerUppgrade.statBonuses.Count > 2)
        {
            button3.GetComponentInChildren<Text>().text = playerUppgrade.statBonuses[2].bonusName;
            button3.gameObject.SetActive(true);
        }
        else
        {
            button3.gameObject.SetActive(false);
        } // Show the panel
    }
    public void OnUpgradeButtonClicked(int index)
    {
        indexToReplace = index; // Set the index of the upgrade to replace
        ReplaceStatBonus(newBonus, indexToReplace);
        playerUppgrade.Closereplacementpanel(); // Hide the panel after the replacement
    }

    private void ReplaceStatBonus(StatBonus newBonus, int index)
    {
        if (index >= 0 && index < playerUppgrade.statBonuses.Count)
        {
            playerUppgrade.statBonuses[index] = newBonus; // Replace the old bonus with the new one
            Debug.Log("Replaced bonus at index " + index + " with " + newBonus.bonusName);
            ApplyBonusToPlayer(newBonus); // Apply the new bonus to the player
        }
        HealthBarScript healthBar = FindObjectOfType<HealthBarScript>();
        healthBar.DrawHearts();
    }
   


    private void ApplyBonusToPlayer(StatBonus bonus)
    {
        PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
        if (playerCombat != null)
        {
            bonus.ApplyBonus(playerCombat); // Apply the bonus to the player's combat stats
        }
        else
        {
            Debug.LogWarning("PlayerCombat component not found on player.");
        }
    }
    public void power1()
    {
        AddStatBonus("Power Bonus 1", 2.0f, BonusType.Power);
        panel.SetActive(false);

    }
    public void power2()
    {
        AddStatBonus("Power Bonus 2", 4.0f, BonusType.Power);
        panel.SetActive(false);
    }
    public void power3()
    {
        AddStatBonus("Power Bonus 3", 6.0f, BonusType.Power);
        panel.SetActive(false);
    }
    public void haste1()
    {
        AddStatBonus("Haste Bonus 1", 1.0f, BonusType.Haste);
        panel.SetActive(false);
    }
    public void haste2()
    {
        AddStatBonus("Haste Bonus 1", 2.0f, BonusType.Haste);
        panel.SetActive(false);
    }
    public void haste3()
    {
        AddStatBonus("Haste Bonus 1", 4.0f, BonusType.Haste);
        panel.SetActive(false);
    }
    public void speed1()
    {
        AddStatBonus("Speed Bonus 1", 0.5f, BonusType.Speed);
        panel.SetActive(false);
    }
    public void speed2()
    {
        AddStatBonus("Speed Bonus 2", 1.0f, BonusType.Speed);
        panel.SetActive(false);
    }
    public void speed3()
    {
        AddStatBonus("Speed Bonus 3", 1.5f, BonusType.Speed);
        panel.SetActive(false);
    }
    public void maxhp1()
    {
        AddStatBonus("Max HP Bonus 1", 2.0f, BonusType.MaxHP);
        HealthBarScript healthBar = FindObjectOfType<HealthBarScript>();
        healthBar.DrawHearts();
        panel.SetActive(false);
    }
    public void maxhp2()
    {
        AddStatBonus("Max HP Bonus 2", 4.0f, BonusType.MaxHP);
        HealthBarScript healthBar = FindObjectOfType<HealthBarScript>();
        healthBar.DrawHearts();
        panel.SetActive(false);
    }
    public void maxhp3()
    {
        AddStatBonus("Max HP Bonus 3", 6.0f, BonusType.MaxHP);
        HealthBarScript healthBar = FindObjectOfType<HealthBarScript>();
        healthBar.DrawHearts();
        panel.SetActive(false);
    }

}
[System.Serializable]
public class StatBonus
{
    public string bonusName; // Name of the bonus
    public float bonusValue; // Value of the bonus
    public BonusType bonusType; // Type of bonus

    public StatBonus(string name, float value, BonusType type)
    {
        bonusName = name;
        bonusValue = value;
        bonusType = type;
    }

    public void ApplyBonus(PlayerCombat playerCombat)
    {
        switch (bonusType)
        {
            case BonusType.MaxHP:
                playerCombat.maxHP += bonusValue;
                break;
            case BonusType.Speed:
                NavMeshAgent agent = playerCombat.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.speed += bonusValue;
                }
                break;
            case BonusType.Power:
                playerCombat.attackPower += bonusValue;
                break;
            case BonusType.Haste:
                playerCombat.attackSpeed += bonusValue;
                break;
                // Add more cases for other bonus types as needed
        }
    }
    public void RemoveBonus(PlayerCombat playerCombat)
    {
        switch (bonusType)
        {
            case BonusType.MaxHP:
                playerCombat.maxHP -= bonusValue;
                Debug.Log("Does work");
                break;
            case BonusType.Speed:
                NavMeshAgent agent = playerCombat.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.speed -= bonusValue;
                }
                break;
            case BonusType.Power:
                playerCombat.attackPower -= bonusValue;
                break;
            case BonusType.Haste:
                playerCombat.attackSpeed -= bonusValue;
                break;
                // Add more cases for other bonus types as needed
        }
    }   
}

public enum BonusType
{
    MaxHP,
    Speed,
    Power,
    Haste,
    // Add other bonus types here
}
