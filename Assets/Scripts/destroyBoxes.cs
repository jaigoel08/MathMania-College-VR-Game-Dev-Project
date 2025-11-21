using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBoxes : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "destroyBox")
        {
            Destroy(col.gameObject);
            Debug.Log("collision detected!");
        }
    }
}
