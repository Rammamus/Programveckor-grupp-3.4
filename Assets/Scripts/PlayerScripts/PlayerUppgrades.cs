using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUppgrades : MonoBehaviour
{
    public List<StatBonus> statBonuses = new List<StatBonus>();
    public static int maxSlots = 3;
    public GameObject replacementpanel;
    public void Openreplacementpanel()
    {
        replacementpanel.SetActive(true);
    }
    public void Closereplacementpanel()
    {
        replacementpanel.SetActive(false);

    }
}
