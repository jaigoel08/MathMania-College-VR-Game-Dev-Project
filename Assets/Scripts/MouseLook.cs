using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    public float mouseSensitivity = 100f;
    
    [Header("References")]
    public Transform playerBody;
    
    [Header("Look Constraints")]
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;
    
    private float xRotation = 0f;
    
    void Start()
    {
        // Lock and hide cursor for better aiming
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // If playerBody not assigned, try to find it
        if (playerBody == null)
        {
            // Look for parent with CharacterController or tag "Player"
            if (transform.parent != null)
                playerBody = transform.parent;
        }
    }
    
    void Update()
    {
        // Press Escape to unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        // Click to lock cursor again
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        // Only rotate camera if cursor is locked
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            HandleMouseLook();
        }
    }
    
    void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // Rotate camera up/down (X axis rotation)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Rotate player body left/right (Y axis rotation)
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
