using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
           // ReplaceStatBonus(newBonus);
        }
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
                //playerCombat.attackpower += bonusValue;
                break;
            case BonusType.Haste;
                playerCombat.haste += bonusValue;
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
