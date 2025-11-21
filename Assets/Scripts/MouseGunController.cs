using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGunController : MonoBehaviour
{
    [Header("Gun Settings")]
    public GameObject bullet;
    public Transform barrelPivot;
    public float shootingSpeed = 20f;
    
    [Header("Pickup Settings")]
    public float pickupRange = 3f;
    public LayerMask gunLayer;
    public Transform gunHoldPosition; // Position where gun will be held (in front of camera)
    
    [Header("Aiming Settings")]
    public float mouseSensitivity = 2f;
    public Camera playerCamera;
    
    private GameObject leftGun;
    private GameObject rightGun;
    private bool holdingLeftGun = false;
    private bool holdingRightGun = false;
    
    private Rigidbody leftGunRb;
    private Rigidbody rightGunRb;
    
    [Header("Gun Positions")]
    public Vector3 leftGunOffset = new Vector3(-0.3f, -0.2f, 0.5f);
    public Vector3 rightGunOffset = new Vector3(0.3f, -0.2f, 0.5f);
    
    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;
            
        // Create gun hold positions if not assigned
        if (gunHoldPosition == null)
        {
            GameObject holder = new GameObject("GunHolder");
            gunHoldPosition = holder.transform;
            gunHoldPosition.parent = playerCamera.transform;
            gunHoldPosition.localPosition = Vector3.zero;
        }
    }
    
    void Update()
    {
        // Left Mouse Button - Pick up/shoot left gun
        if (Input.GetMouseButtonDown(0))
        {
            if (!holdingLeftGun)
                TryPickupGun(true); // true = left gun
            else
                ShootGun(leftGun);
        }
        
        // Right Mouse Button - Pick up/shoot right gun
        if (Input.GetMouseButtonDown(1))
        {
            if (!holdingRightGun)
                TryPickupGun(false); // false = right gun
            else
                ShootGun(rightGun);
        }
        
        // Q key - Drop left gun
        if (Input.GetKeyDown(KeyCode.Q) && holdingLeftGun)
        {
            DropGun(true);
        }
        
        // E key - Drop right gun
        if (Input.GetKeyDown(KeyCode.E) && holdingRightGun)
        {
            DropGun(false);
        }
        
        // Update gun positions and rotations
        if (holdingLeftGun && leftGun != null)
        {
            UpdateGunPosition(leftGun, leftGunOffset);
        }
        
        if (holdingRightGun && rightGun != null)
        {
            UpdateGunPosition(rightGun, rightGunOffset);
        }
    }
    
    void TryPickupGun(bool isLeftGun)
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            // Check if the object has a gun tag or shoot script
            if (hit.collider.CompareTag("Gun") || hit.collider.GetComponent<shoot>() != null)
            {
                GameObject gun = hit.collider.gameObject;
                
                if (isLeftGun)
                {
                    leftGun = gun;
                    holdingLeftGun = true;
                    leftGunRb = gun.GetComponent<Rigidbody>();
                    if (leftGunRb != null)
                    {
                        leftGunRb.isKinematic = true;
                        leftGunRb.useGravity = false;
                    }
                    Debug.Log("Picked up left gun");
                }
                else
                {
                    rightGun = gun;
                    holdingRightGun = true;
                    rightGunRb = gun.GetComponent<Rigidbody>();
                    if (rightGunRb != null)
                    {
                        rightGunRb.isKinematic = true;
                        rightGunRb.useGravity = false;
                    }
                    Debug.Log("Picked up right gun");
                }
            }
        }
    }
    
    void UpdateGunPosition(GameObject gun, Vector3 offset)
    {
        if (gun == null || playerCamera == null) return;
        
        // Position gun relative to camera
        Vector3 targetPosition = playerCamera.transform.position + 
                                playerCamera.transform.TransformDirection(offset);
        gun.transform.position = targetPosition;
        
        // Rotate gun to face where camera is looking
        gun.transform.rotation = playerCamera.transform.rotation;
    }
    
    void ShootGun(GameObject gun)
    {
        if (gun == null) return;
        
        shoot shootScript = gun.GetComponent<shoot>();
        if (shootScript != null && shootScript.bullet != null && shootScript.barrelPivot != null)
        {
            Debug.Log("Shooting gun!");
            
            // Create bullet
            GameObject bulletObj = Instantiate(shootScript.bullet, 
                                              shootScript.barrelPivot.position, 
                                              shootScript.barrelPivot.rotation);
            
            Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // Shoot in the direction the camera is facing
                bulletRb.velocity = playerCamera.transform.forward * shootScript.shootingSpeed;
            }
        }
    }
    
    void DropGun(bool isLeftGun)
    {
        if (isLeftGun && leftGun != null)
        {
            if (leftGunRb != null)
            {
                leftGunRb.isKinematic = false;
                leftGunRb.useGravity = true;
            }
            leftGun = null;
            holdingLeftGun = false;
            Debug.Log("Dropped left gun");
        }
        else if (!isLeftGun && rightGun != null)
        {
            if (rightGunRb != null)
            {
                rightGunRb.isKinematic = false;
                rightGunRb.useGravity = true;
            }
            rightGun = null;
            holdingRightGun = false;
            Debug.Log("Dropped right gun");
        }
    }
    
    void OnDrawGizmos()
    {
        // Draw pickup range in editor
        if (playerCamera != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * pickupRange);
        }
    }
}
