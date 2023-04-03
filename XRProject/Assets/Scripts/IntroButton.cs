using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{
    public TextMeshPro typedText;
    public TextMeshPro buttonText;
    public TextMeshPro displayText;
    public Canvas numpad;
    public TextMeshPro outputText;
    public static string PID;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        if(index != 1)
        {
            index = 1;
            displayText.enabled = false;
            outputText.enabled = true; 
            typedText.text = "Please enter the participant ID provided to you";
            typedText.enabled = true;
            numpad.enabled = true;
            buttonText.text = "Start";
        }
        else
        {
            PID = "FP3" + outputText.text;
            SceneManager.LoadScene("SphericalSceneController");
        }
    }
}
