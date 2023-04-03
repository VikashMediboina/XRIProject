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
    public GameObject numpad;
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
            displayText.enabled =false;
            outputText.enabled = true; 
            typedText.text = "Please enter the participant ID provided to you";
            typedText.enabled = true;
            numpad.SetActive(true);
            buttonText.text = "Start";
        }
        else
        {
            if (outputText.text != "" && outputText.text != "Enter PID")
            {
                PID = "FP3" + outputText.text;
                PlayerPrefs.SetString("PID", PID);
                SceneManager.LoadScene("SphericalSceneController");
            }

        }
    }
}
