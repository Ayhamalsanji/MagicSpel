using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScptTEST : MonoBehaviour
{
    public GameObject FireBall;           // Referens till eldklotets prefab
    public float fireBallSpeed = 10f;     // Hastigheten på eldklotet
    public float fireRate = 0.3f;         // Tidsintervall mellan varje skott
    private float nextFireTime = 0f;      // Tidpunkt när spelaren kan skjuta igen
    private bool canCast = true;          // Om spelaren kan skjuta eller inte

    // Update is called once per frame
    void Update()
    {
        // Kolla om mellanslag är nedtryckt och om vi kan skjuta
        if (Input.GetKeyDown(KeyCode.Space) && canCast)
        {
            ShootFireBall();  // Skjut eldklotet
            canCast = false;  // Förhindra fler skott tills fireRate har gått ut
            nextFireTime = Time.time + fireRate;  // Beräkna nästa tillåtna skottid
        }

        // Om tiden har gått för fireRate, tillåt att skjuta igen
        if (Time.time >= nextFireTime)
        {
            canCast = true;  // Tillåt att skjuta igen
        }
    }

    // Metod för att skapa eldklotet
    void ShootFireBall()
    {
        if (FireBall != null)
        {
            // Skapa eldklotet på spelarens position och rotation
            GameObject fireballInstance = Instantiate(FireBall, transform.position, transform.rotation);

            // Ge eldklotet en hastighet framåt
            Rigidbody2D rb = fireballInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * fireBallSpeed;  // Rörelse framåt i spelarens riktning
            }
        }
        else
        {
            Debug.LogError("Fireball Prefab saknas! Tilldela en prefab i inspektorn.");
        }
    }
}
