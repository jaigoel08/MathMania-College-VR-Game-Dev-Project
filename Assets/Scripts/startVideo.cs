using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.InteractionSystem;

public class startVideo : MonoBehaviour
{
    public AudioSource sound;
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    public void OnPress(Hand hand)
    {
        videoPlayer.Play();
        sound.Play();

    }
}
