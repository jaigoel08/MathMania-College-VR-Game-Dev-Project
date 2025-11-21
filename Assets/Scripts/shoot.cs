using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class shoot : MonoBehaviour
{
    [Header("VR Settings")]
    public SteamVR_Action_Boolean fireAction;
    
    [Header("Gun Settings")]
    public GameObject bullet;
    public Transform barrelPivot;
    public float shootingSpeed = 1;
    //public GameObject muzzelFlash;

    [Header("Mouse Controls")]
    public bool enableMouseShooting = true;
    public KeyCode shootKey = KeyCode.Mouse0; // Left mouse button
    public float shootCooldown = 0.2f; // Prevent spam clicking
    
    private Animator animator;
    private Interactable interactable;
    private float lastShootTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //muzzelFlash.SetActive(false);
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        // VR Shooting (original code)
        if (interactable != null && interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (fireAction != null && fireAction[source].stateDown)
            {
                fire();
            }
        }
        
        // Mouse Shooting (new feature - works without VR)
        if (enableMouseShooting && Input.GetKeyDown(shootKey))
        {
            // Check cooldown
            if (Time.time - lastShootTime >= shootCooldown)
            {
                fire();
                lastShootTime = Time.time;
            }
        }
    }

    void fire()
    {
        if (bullet == null || barrelPivot == null)
        {
            Debug.LogWarning("Gun not properly configured! Missing bullet or barrelPivot.");
            return;
        }
        
        Debug.Log("fired");
        Rigidbody bulletrb = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation).GetComponent<Rigidbody>();
        
        if (bulletrb != null)
        {
            bulletrb.velocity = barrelPivot.forward * shootingSpeed;
        }
        //muzzelFlash.SetActive(true);
    }
}
