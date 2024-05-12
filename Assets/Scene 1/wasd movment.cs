//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class wasdmovment : MonoBehaviour
//{
//    public float speed = 5.0f; // Movement speed

//    void Update()
//    {
//        // Get movement direction based on WASD keys
//        float horizontalInput = Input.GetAxisRaw("Horizontal");
//        float verticalInput = Input.GetAxisRaw("Vertical");

//        // Create a movement vector
//        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

//        // Apply movement to the transform
//        transform.Translate(movement);
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wasdmovement : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float jumpForce = 5.0f; // Force applied for jumping

    private bool isGrounded = true; // Tracks if character is on the ground

    void Update()
    {
        // Get movement direction based on WASD keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

        // Apply movement to the transform
        transform.Translate(movement);

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply jump force if grounded and space is pressed
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision) // Detects collision for grounding
    {
        if (collision.gameObject.tag == "Ground") // Adjust tag name if needed
        {
            isGrounded = true;
        }
    }
}
