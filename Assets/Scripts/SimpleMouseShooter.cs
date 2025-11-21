using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float shootCooldown = 0.3f;
    
    [Header("Spawn Settings")]
    public Transform bulletSpawnPoint; // Where bullets spawn from
    
    [Header("Controls")]
    public KeyCode shootKey = KeyCode.Mouse0; // Left mouse button
    
    [Header("Optional - Crosshair")]
    public bool showCrosshair = true;
    public Texture2D crosshairTexture;
    
    private float lastShootTime = 0f;
    private Camera playerCamera;
    
    void Start()
    {
        playerCamera = Camera.main;
        
        // Create bullet spawn point if not assigned
        if (bulletSpawnPoint == null)
        {
            GameObject spawnObj = new GameObject("BulletSpawnPoint");
            bulletSpawnPoint = spawnObj.transform;
            bulletSpawnPoint.parent = playerCamera.transform;
            bulletSpawnPoint.localPosition = new Vector3(0, -0.1f, 0.5f); // Slightly below center of screen
        }
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        // Unlock cursor with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        // Lock cursor with click
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        // Shoot
        if (Input.GetKey(shootKey) && Time.time - lastShootTime >= shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }
    
    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogWarning("No bullet prefab assigned!");
            return;
        }
        
        // Get the center of the screen (where camera is looking)
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        
        // Spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        
        // Aim bullet towards where camera is looking
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = ray.direction * bulletSpeed;
        }
        
        // Optional: Rotate bullet to face direction
        bullet.transform.rotation = Quaternion.LookRotation(ray.direction);
        
        Debug.Log("Shot fired at target!");
    }
    
    void OnGUI()
    {
        if (showCrosshair && Cursor.lockState == CursorLockMode.Locked)
        {
            float crosshairSize = 20f;
            
            // Draw simple crosshair if no texture provided
            if (crosshairTexture == null)
            {
                // Horizontal line
                GUI.Box(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 1, 20, 2), "");
                // Vertical line
                GUI.Box(new Rect(Screen.width / 2 - 1, Screen.height / 2 - 10, 2, 20), "");
            }
            else
            {
                GUI.DrawTexture(new Rect(Screen.width / 2 - crosshairSize / 2, 
                                        Screen.height / 2 - crosshairSize / 2, 
                                        crosshairSize, crosshairSize), 
                               crosshairTexture);
            }
        }
    }
}
