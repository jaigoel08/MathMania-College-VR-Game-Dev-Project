using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class sceneController : MonoBehaviour
{
    public AudioSource sound;

    public void OnPress(Hand hand)
    {
        SceneManager.LoadScene("AppleSceneRestart");
        scoreScript.scoreValue = 0;
        scoreScript2.scoreValue2 = 0;
        scoreScript3.scoreValue3 = 0;
        sound.Play();
       

    }

}
