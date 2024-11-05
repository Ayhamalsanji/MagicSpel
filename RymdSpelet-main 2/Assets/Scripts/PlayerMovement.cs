using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hastigheten som spelaren r�r sig med
    private Camera cam; // Kamerareferens f�r att f� spelytans gr�nser

    void Start()
    {
        cam = Camera.main; // H�mta huvudkameran
    }

    void Update()
    {
        // Hantera spelarens input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Flytta spelaren
        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);

        // Hantera wraparound (spawna p� motsatt sida om spelaren �ker utanf�r sk�rmen)
        WrapAround();
    }

    void WrapAround()
    {
        // H�mta kamerans gr�nser
        float screenLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float screenBottom = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float screenTop = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        // Kolla om spelaren har g�tt utanf�r sk�rmen och flytta tillbaka dem till motsatt sida
        if (transform.position.x < screenLeft)
        {
            transform.position = new Vector3(screenRight, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > screenRight)
        {
            transform.position = new Vector3(screenLeft, transform.position.y, transform.position.z);
        }

        if (transform.position.y < screenBottom)
        {
            transform.position = new Vector3(transform.position.x, screenTop, transform.position.z);
        }
        else if (transform.position.y > screenTop)
        {
            transform.position = new Vector3(transform.position.x, screenBottom, transform.position.z);
        }
    }
}
