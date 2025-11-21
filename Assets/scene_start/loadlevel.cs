using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class loadlevel : MonoBehaviour
{
    public AudioSource sound;

    public void OnPress(Hand hand)
    {
        Debug.Log("SteamVR Button pressed!");
        SceneManager.LoadScene("AppleScene");
        sound.Play();
    }


}