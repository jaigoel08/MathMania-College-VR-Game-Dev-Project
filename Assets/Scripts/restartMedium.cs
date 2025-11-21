using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class restartMedium : MonoBehaviour
{
    public void OnPress(Hand hand)
    {
        SceneManager.LoadScene("multimedium");



    }
}
