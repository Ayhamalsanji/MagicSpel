using UnityEngine;

public class heartHealthBar2 : MonoBehaviour
{
    public GameObject[] healthHearts; // Array of heart GameObjects

    public void UpdateHealth(int playerHealth)
    {
        for (int i = 0; i < healthHearts.Length; i++)
        {
            var heartChanger = healthHearts[i].GetComponent<HeartSpriteChanger>();

            if (heartChanger == null)
            {
                Debug.LogError($"Heart GameObject {healthHearts[i].name} is missing HeartSpriteChanger component!");
                continue;
            }

            if (playerHealth >= (i + 1) * 2)
            {
                // Full heart if health is enough for this heart
                heartChanger.SetFullHeart();
            }
            else if (playerHealth == (i * 2) + 1)
            {
                // Half heart if health is exactly halfway
                heartChanger.SetHalfHeart();
            }
            else
            {
                // Empty heart otherwise
                heartChanger.SetEmptyHeart();
            }
        }
    }
}
