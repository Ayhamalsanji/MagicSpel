using UnityEngine;
using UnityEngine.UI;

public class HeartSpriteChanger : MonoBehaviour
{
    public Sprite fullHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite emptyHeartSprite;

    private Image heartImage;

    void Awake()
    {
        heartImage = GetComponent<Image>();

        if (heartImage == null)
        {
            Debug.LogError($"No Image component found on {gameObject.name}! Please attach one.");
        }
    }

    public void SetFullHeart()
    {
        if (fullHeartSprite != null)
        {
            heartImage.sprite = fullHeartSprite;
        }
        else
        {
            Debug.LogError($"Full heart sprite is missing on {gameObject.name}!");
        }
    }

    public void SetHalfHeart()
    {
        if (halfHeartSprite != null)
        {
            heartImage.sprite = halfHeartSprite;
        }
        else
        {
            Debug.LogError($"Half heart sprite is missing on {gameObject.name}!");
        }
    }

    public void SetEmptyHeart()
    {
        if (emptyHeartSprite != null)
        {
            heartImage.sprite = emptyHeartSprite;
        }
        else
        {
            Debug.LogError($"Empty heart sprite is missing on {gameObject.name}!");
        }
    }
}
