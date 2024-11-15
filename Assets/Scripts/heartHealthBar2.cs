using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartHealthBar2 : MonoBehaviour
{
    public GameObject[] healthHearts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int playerhealth)
    {
        //If health is more than 4
        healthHearts[2].GetComponent<HeartSpriteChanger>().ImageUpdate();

        //If health is less than 5 and more than 2
        //Do something with heart 2

        //If health is less than 3
        //Do something with heart 1
    }
}
