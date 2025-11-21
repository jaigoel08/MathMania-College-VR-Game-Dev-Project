using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class restartHard : MonoBehaviour
{
    public AudioSource sound;

    public void OnPress(Hand hand)
    {
        SceneManager.LoadScene("multihard");
        sound.Play();



    }
}
