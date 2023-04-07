using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class EndButton : MonoBehaviour
{
    public TextMeshPro keyboardQ;
    public TextMeshPro ageQ;
    public TextMeshPro genderQ;
    public TextMeshPro vrQ;
    public TextMeshPro displayText;
    public TextMeshPro outputText;
    public TextMeshPro buttonText;
    public GameObject ageNumpad;
    public GameObject keyboardButtons;
    public GameObject genderButtons;
    public GameObject vrButtons;
    public GameObject nextButton;
    private string url;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        url = "https://neu.co1.qualtrics.com/jfe/form/SV_50ZWxzp9DURyYwm";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        if(index == 0)
        {
            index += 1;
            keyboardQ.enabled = false;
            keyboardButtons.SetActive(false);
            ageQ.enabled = true;
            ageNumpad.SetActive(true);
            outputText.enabled = true;
        }
        else if(index == 1)
        {
            index += 1;
            ageQ.enabled = false;
            ageNumpad.SetActive(false);
            outputText.enabled = false;
            genderQ.enabled = true;
            genderButtons.SetActive(true);
        }
        else if(index == 2)
        {
            index += 1;
            genderQ.enabled = false;
            genderButtons.SetActive(false);
            vrQ.enabled = true;
            vrButtons.SetActive(true);
            buttonText.text = "End";
        }
        else if(index == 3)
        {
            index += 1;
            vrQ.enabled = false;
            vrButtons.SetActive(false);
            nextButton.SetActive(false);
            displayText.enabled = true;
            sendQualtricsData();
        }
    }

    public IEnumerator sendQualtricsData()
    {
        WWWForm survey = new WWWForm();
        survey.AddField("PID", PlayerPrefs.GetString("PID"));
        survey.AddField("Key_Type", KeyboardChoice.selection);
        if(outputText.text == "Enter Age")
        {
            survey.AddField("Age", "0");
        }
        else
        {
            survey.AddField("Age", outputText.text);
        }
        survey.AddField("Gender", GenderChoice.selection);
        survey.AddField("VR_User", VRChoice.selection);
        UnityWebRequest form = UnityWebRequest.Post(url, survey);
        yield return form.SendWebRequest();
    }
}
