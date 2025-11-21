using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class problemcube : MonoBehaviour
{
    public int cubeId;  

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            // tell the game manager that the player entered this tube
            gamemanager.instance.OnAppleCollision(cubeId);
            Debug.Log("hit");
           
        }

    }

}