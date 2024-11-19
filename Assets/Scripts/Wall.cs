using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            // Destroy the fireball on collision
            Debug.Log("Enemy hit by fireball. Destroying fireball.");
            Destroy(collision.gameObject);
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
