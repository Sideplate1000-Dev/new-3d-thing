using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMouseLook : MonoBehaviour
{
    public float sensitivity = 0.5f;

    // Separate variables for camera and object rotation
    private Vector3 cameraRotation;
    private Vector3 objectRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse movement on the X axis for object rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        objectRotation.y += mouseX;

        // Get mouse movement on the Y axis for camera rotation
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotation.x -= mouseY; // Invert Y for natural camera movement

        // Clamp camera rotation (optional, adjust limits as needed)
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -80f, 80f);

        // Apply object rotation
        transform.localEulerAngles = objectRotation;

        // Apply camera rotation to the camera child (assuming there's a camera child)
        if (transform.childCount > 0)
        {
            transform.GetChild(0).transform.localEulerAngles = cameraRotation;
        }
    }
}
