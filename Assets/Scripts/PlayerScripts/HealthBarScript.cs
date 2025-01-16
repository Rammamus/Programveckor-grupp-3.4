using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerCombat playerHealth;
    List<HealthBarHearts> hearts = new List<HealthBarHearts>();

    void OnEnable()
    {
        PlayerCombat.OnPlayerDamaged += DrawHearts;
    }

    void OnDisable()
    {
        PlayerCombat.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerCombat>();
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = playerHealth.maxHP % 2;
        int heartsToMake = (int)((playerHealth.maxHP / 2) + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.hp - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
            hearts[i].GetComponent<Image>().enabled = true;
            hearts[i].GetComponent<LayoutElement>().enabled = true;
            hearts[i].GetComponent<HealthBarHearts>().enabled = true;
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthBarHearts heartComponent = newHeart.GetComponent<HealthBarHearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthBarHearts>();
    }
}
