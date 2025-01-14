using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonupgrader : MonoBehaviour
{
    public GameObject Upgradepanel;
    public GameObject player;
    public void power1()
    {

    }
    public void power2()
    {

    }
    public void power3()
    {

    }
    public void haste1()
    {

    }
    public void haste2()
    {

    }
    public void haste3()
    {

    }
    public void speed1()
    {

    }
    public void speed2()
    {

    }
    public void speed3()
    {

    }
    public void maxhp1()
    {
        PlayerCombat.FindAnyObjectByType<PlayerCombat>().maxHP += 2;
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        Upgradepanel.SetActive(false);
    }
    public void maxhp2()
    {
        PlayerCombat.FindAnyObjectByType<PlayerCombat>().maxHP += 4;
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        Upgradepanel.SetActive(false);
    }
    public void maxhp3()
    {
        PlayerCombat.FindAnyObjectByType<PlayerCombat>().maxHP += 6;
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        Upgradepanel.SetActive(false);
    }
}
