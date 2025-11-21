using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class answerScript : MonoBehaviour
{
    public AudioSource sound;
    public Text correct;
    private GameObject hidey;
    // Start is called before the first frame update
    void Start()
    {
        correct = GetComponent<Text>();
        hidey = GameObject.Find("Learn");
        hidey.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress(Hand hand)
    {
        Debug.Log("Submit Button pressed!");
        if (scoreScript.scoreValue == 9 && scoreScript2.scoreValue2 == 9 && scoreScript3.scoreValue3 == 9)
        {
            correct.text = "Correct answer. Congratulations !!!";
        }
        else
        {
            correct.text = "Wrong answer. Dont worry, press the Restart button to try again or press the Learn button to find out how to solve the question";
            hidey.gameObject.SetActive(true);
        }
        sound.Play();
    }
}
