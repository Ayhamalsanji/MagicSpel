using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;

public class HeartSpriteChanger : MonoBehaviour
{
    private Image HeartImage;

    public Sprite HeartImageFull;
    public Sprite HeartImageHalf;
    public Sprite HeartImageEmpty;

    int index = 2;

    // Start is called before the first frame update
    void Start()
    {
        HeartImage = GetComponent<Image>();
        ImageUpdate();
    }

    // Update is called once per frame
    public void ImageUpdate()
    {
        if (index == 2)
        {
            HeartImage.sprite = HeartImageFull;
            index--;
        } 
        
        else if (index == 1)
        {
            HeartImage.sprite = HeartImageHalf;
            index--;
        }

        else if (index == 0)
        {
            HeartImage.sprite = HeartImageEmpty;
        }
    }
}
