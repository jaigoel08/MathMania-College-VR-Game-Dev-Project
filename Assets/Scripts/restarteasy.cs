using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class restarteasy : MonoBehaviour
{
    public void OnPress(Hand hand)
    {
        SceneManager.LoadScene("multiplicationscene");
        


    }
}
