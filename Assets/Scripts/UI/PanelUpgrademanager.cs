using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class PanelUpgrademanager : MonoBehaviour
{
    public List<GameObject> item;
    public Transform panel;

    // Update is called once per frame
    public void OnEnable()
    {
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }
        System.Random random = new System.Random();
        var selectedItems = item.OrderBy(x => random.Next()).Take(3).ToList();
        foreach (var item in selectedItems)
        {
            GameObject button = Instantiate(item, panel);
        }
    }
}
