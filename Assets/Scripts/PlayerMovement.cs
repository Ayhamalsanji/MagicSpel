//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float moveSpeed = 5.0f;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float moveX = Input.GetAxisRaw("Horizontal");
//        float moveY = Input.GetAxisRaw("Vertical");

//        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);

//    }
//}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float moveSpeed = 5.0f;   // Movement speed
//    private Rigidbody2D rb;           // Reference to the Rigidbody2D component

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Get the Rigidbody2D component attached to the player
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float moveX = Input.GetAxisRaw("Horizontal");  // Get horizontal input
//        float moveY = Input.GetAxisRaw("Vertical");    // Get vertical input

//        // Set velocity using Rigidbody2D to move the player
//        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
//    }
//}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float moveSpeed = 5.0f;   // Movement speed
//    public bool canMove = true;       // Can the player move?

//    private Rigidbody2D rb;           // Reference to the Rigidbody2D component

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
//    }

//    void Update()
//    {
//        if (canMove)  // Only allow movement if canMove is true
//        {
//            float moveX = Input.GetAxisRaw("Horizontal");  // Get horizontal input
//            float moveY = Input.GetAxisRaw("Vertical");    // Get vertical input

//            // Set velocity using Rigidbody2D to move the player
//            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
//        }
//        else
//        {
//            // If the player can't move, ensure the velocity is set to 0
//            rb.velocity = Vector2.zero;
//        }
//    }
//}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float moveSpeed = 5.0f;  // Movement speed
//    private bool canMove = true;     // Whether the player can move
//    private Rigidbody2D rb;          // Reference to the Rigidbody2D component

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
//    }

//    void Update()
//    {
//        if (canMove)  // Only allow movement if canMove is true
//        {
//            float moveX = Input.GetAxisRaw("Horizontal");  // Get horizontal input
//            float moveY = Input.GetAxisRaw("Vertical");    // Get vertical input

//            // Set velocity using Rigidbody2D to move the player
//            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
//        }
//        else
//        {
//            // If the player can't move, ensure the velocity is set to 0
//            rb.velocity = Vector2.zero;
//        }
//    }

//    // Disable movement (called by the Shooting script)
//    public void DisableMovement()
//    {
//        canMove = false;
//    }

//    // Enable movement (called by the Shooting script after fireRate)
//    public void EnableMovement()
//    {
//        canMove = true;
//    }
//}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Movement speed
    private bool canMove = true;     // Whether the player can move
    private Rigidbody2D rb;          // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
    }

    void Update()
    {
        if (canMove)  // Only allow movement if canMove is true
        {
            float moveX = Input.GetAxisRaw("Horizontal");  // Get horizontal input
            float moveY = Input.GetAxisRaw("Vertical");    // Get vertical input

            // Set velocity using Rigidbody2D to move the player
            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        }
        else
        {
            // If the player can't move, ensure the velocity is set to 0
            rb.velocity = Vector2.zero;
        }
    }

    // Disable movement (called by the Shooting script)
    public void DisableMovement()
    {
        canMove = false;
    }

    // Enable movement (called by the Shooting script after fireRate)
    public void EnableMovement()
    {
        canMove = true;
    }
}


