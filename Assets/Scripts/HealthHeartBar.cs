using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    List<HealthHearts> hearts = new List<HealthHearts>();

    public void DrawHearts()
    {
        ClearHearts();

        // determine how many hearts Ito make total
        // based off the max health

        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();  // make total hearts needed
        }
    }

    public void CreateEmptyHeart()
    {

      GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHearts heartComponent = newHeart.GetComponent<HealthHearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);

    }
          
    public void ClearHearts()
    {

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);

        }

        hearts = new List<Hea1thHearts>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
