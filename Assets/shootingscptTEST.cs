using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScptTEST : MonoBehaviour
{
    public GameObject FireBall;           // Referens till eldklotets prefab
    public float fireBallSpeed = 10f;     // Hastigheten p� eldklotet
    public float fireRate = 0.3f;         // Tidsintervall mellan varje skott
    private float nextFireTime = 0f;      // Tidpunkt n�r spelaren kan skjuta igen
    private bool canCast = true;          // Om spelaren kan skjuta eller inte

    // Update is called once per frame
    void Update()
    {
        // Kolla om mellanslag �r nedtryckt och om vi kan skjuta
        if (Input.GetKeyDown(KeyCode.Space) && canCast)
        {
            ShootFireBall();  // Skjut eldklotet
            canCast = false;  // F�rhindra fler skott tills fireRate har g�tt ut
            nextFireTime = Time.time + fireRate;  // Ber�kna n�sta till�tna skottid
        }

        // Om tiden har g�tt f�r fireRate, till�t att skjuta igen
        if (Time.time >= nextFireTime)
        {
            canCast = true;  // Till�t att skjuta igen
        }
    }

    // Metod f�r att skapa eldklotet
    void ShootFireBall()
    {
        if (FireBall != null)
        {
            // Skapa eldklotet p� spelarens position och rotation
            GameObject fireballInstance = Instantiate(FireBall, transform.position, transform.rotation);

            // Ge eldklotet en hastighet fram�t
            Rigidbody2D rb = fireballInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * fireBallSpeed;  // R�relse fram�t i spelarens riktning
            }
        }
        else
        {
            Debug.LogError("Fireball Prefab saknas! Tilldela en prefab i inspektorn.");
        }
    }
}
