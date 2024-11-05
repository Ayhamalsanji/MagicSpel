using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;  // Prefab f�r lasern
    public float laserSpeed = 10f;  // Hastigheten p� lasern
    public float fireRate = 0.5f;   // Tiden mellan skott (cooldown)
    public float laserLifetime = 2f; // Hur l�nge lasern existerar innan den f�rst�rs
    public int maxShotsBeforeOverheat = 5; // Max antal skott innan �verhettning
    private int currentShots = 0;          // Nuvarande antal skott
    public float overheatCooldownTime = 2f; // Tid f�r att svalna efter �verhettning
    private bool isOverheated = false;      // Om vapnet �r �verhettat


    private float nextFireTime = 0f; // Tid n�r spelaren kan skjuta igen

    void Update()
    {
        if (isOverheated)
        {
            // Om vapnet �r �verhettat, l�t spelaren v�nta tills cooldown-tiden har passerat
            if (Time.time > nextFireTime)
            {
                isOverheated = false;
                currentShots = 0; // �terst�ll antal skott
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            ShootLaser();
            currentShots++;

            // Kolla om vi har skjutit f�r m�nga g�nger och s�tt vapnet i �verhettning
            if (currentShots >= maxShotsBeforeOverheat)
            {
                isOverheated = true;
                nextFireTime = Time.time + overheatCooldownTime; // V�nta p� cooldown innan n�sta skott
            }
            else
            {
                nextFireTime = Time.time + fireRate;
            }
        }
    }


    void ShootLaser()
    {
        // Skapa laser fr�n spelarens position och rotation
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        // Ge lasern en hastighet fram�t (i positiv Y-riktning)
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * laserSpeed;

        // F�rst�r lasern efter en viss tid
        Destroy(laser, laserLifetime);
    }
}
