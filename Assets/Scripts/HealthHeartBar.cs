using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }

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

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);

    }
          
    public void ClearHearts()
    {

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);

        }

<<<<<<< HEAD
        hearts = new List<HealthHearts>();
=======
        hearts = new List<HealthHeart>();
>>>>>>> e4649e1a9b405a86ca040e1bce654b33f119c134
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
