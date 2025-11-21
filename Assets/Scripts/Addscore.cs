using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Addscore : MonoBehaviour
{
    

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Trigger")
        {
            Debug.Log("wwwwwwwww");
            scoreScript.scoreValue += 1;
        }

        if (otherCollider.tag == "Trigger2")
        {
            Debug.Log("tttttttt");
            scoreScript2.scoreValue2 += 1;
        }

        if (otherCollider.tag == "Trigger3")
        {
            Debug.Log("gggggggg");
            scoreScript3.scoreValue3 += 1;
        }
    }


    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.tag == "Trigger")
        {
            Debug.Log("wwwwwwwww");
            scoreScript.scoreValue --;
        }

        if (otherCollider.tag == "Trigger2")
        {
            Debug.Log("tttttttt");
            scoreScript2.scoreValue2 --;
        }

        if (otherCollider.tag == "Trigger3")
        {
            Debug.Log("gggggggg");
            scoreScript3.scoreValue3 --;
        }
    }


}
