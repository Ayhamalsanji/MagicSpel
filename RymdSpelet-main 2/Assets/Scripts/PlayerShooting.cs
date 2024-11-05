using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;  // Prefab för lasern
    public float laserSpeed = 10f;  // Hastigheten på lasern
    public float fireRate = 0.5f;   // Tiden mellan skott (cooldown)
    public float laserLifetime = 2f; // Hur länge lasern existerar innan den förstörs
    public int maxShotsBeforeOverheat = 5; // Max antal skott innan överhettning
    private int currentShots = 0;          // Nuvarande antal skott
    public float overheatCooldownTime = 2f; // Tid för att svalna efter överhettning
    private bool isOverheated = false;      // Om vapnet är överhettat


    private float nextFireTime = 0f; // Tid när spelaren kan skjuta igen

    void Update()
    {
        if (isOverheated)
        {
            // Om vapnet är överhettat, låt spelaren vänta tills cooldown-tiden har passerat
            if (Time.time > nextFireTime)
            {
                isOverheated = false;
                currentShots = 0; // Återställ antal skott
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            ShootLaser();
            currentShots++;

            // Kolla om vi har skjutit för många gånger och sätt vapnet i överhettning
            if (currentShots >= maxShotsBeforeOverheat)
            {
                isOverheated = true;
                nextFireTime = Time.time + overheatCooldownTime; // Vänta på cooldown innan nästa skott
            }
            else
            {
                nextFireTime = Time.time + fireRate;
            }
        }
    }


    void ShootLaser()
    {
        // Skapa laser från spelarens position och rotation
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        // Ge lasern en hastighet framåt (i positiv Y-riktning)
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * laserSpeed;

        // Förstör lasern efter en viss tid
        Destroy(laser, laserLifetime);
    }
}
