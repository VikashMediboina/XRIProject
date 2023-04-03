using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroNumpad : MonoBehaviour
{
    public Button button;
    public TextMeshPro outputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskOnClick()
    {
        if(outputText.text == "Enter PID")
        {
            outputText.text = "";
            outputText.text += button.ToString().Substring(0, 1);
        }
        else if(outputText.text == "")
        {
            outputText.text = "Enter PID";
        }
        else if(button.ToString().Substring(0, 5) == "Clear")
        {
            outputText.text = "Enter PID";
        }
        else if(button.ToString().Substring(0, 2) == "<-")
        {
            outputText.text = outputText.text.Remove(outputText.text.Length - 1, 1);
            if (outputText.text == "")
            {
                outputText.text = "Enter PID";
            }
        }
        else
        {
            outputText.text += button.ToString().Substring(0,1);
        }
    }
}
