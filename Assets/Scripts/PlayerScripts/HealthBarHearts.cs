using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHearts : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Image heartImage;

    void Start()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}

