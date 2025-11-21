using UnityEngine;
using Valve.VR.InteractionSystem;

public class Events : MonoBehaviour
{
    public AudioSource sound;
    public Transform SpawnPoint;
    public GameObject Prefab;

    public void OnPress(Hand hand)
    {
        Debug.Log("SteamVR Button pressed!");
        Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
        sound.Play();
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }


}