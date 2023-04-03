using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using UnityEngine.Networking;
using UnityEngine.UI;
// using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class changeReferenceText : MonoBehaviour
{
public TextMeshPro typedText; 
public TextMeshPro textToEnter; 
int index=0;
private List<string> textArray =new List<string>(new string[] { "Just playing with you","I did not think we had","Please coordinate with him","On the plane doors closing",
"Thanks for checking with me",
"Take what you can get",
"I heard it was at noon",
"Good to know it exists",
"Thanks again for your help",
"I will handle this afternoon",
"I have ten minutes then",
"I would like to discuss",
"Let me know if I can help",
"It is not working very well",
"I am glad she likes her tree",
"I am monitoring email",
"I will send you minutes",
"Need before board meeting",
"Please revise accordingly",
"I have never worked with her",
"Email the consent to me",
"It reads like she is in",
"Perhaps there was a glitch",
"I would like to attend if so",
"Pressure to finish my review",
"Please set something up",
"Probably will be working",
"I was planning to attend",
"I will be thinking of you",
"Hope you had a good weekend",
"No need to send to FL",
"I am glad you liked it",
"I am glad you are involved",
"Make sure they are current",
"Thus have nothing to destroy",
"I am not aware of any",
"We will keep you posted",
"You can reply via email",
"I am on a conference call",
"A letter is being sent today",
"Need to watch closely",
"Your voice cheered me up",
"I will email later tonight",
"We have lots of paper stuff",
"I am out of town on business",
"I vote for the latter",
"Both of us are still here",
"Just wanted to touch base",
"It will probably be tomorrow"});    


private string PID;
public string Scene_No;
private double Err_Rate;
private int user_Rating;
private string url="https://neu.co1.qualtrics.com/jfe/form/SV_3fT8qgIOPUgibki";
private static Timer Avg_timer;
private static int Total_Timer;
public TextMeshPro buttons;
    // Start is called before the first frame update
    void Start()
    {


        PID = PlayerPrefs.GetString("PID");
        Err_Rate = 0;
        user_Rating = 9;
        url = "https://neu.co1.qualtrics.com/jfe/form/SV_3fT8qgIOPUgibki";
        textToEnter.text=textArray[index];
        Total_Timer = 0;
        this.timerHandler();
    }

    private void timerHandler()
    {
        Avg_timer = new Timer(1000);
        Avg_timer.Elapsed += new ElapsedEventHandler(OnTimer);
        Avg_timer.Enabled = true;
        Avg_timer.AutoReset = false;
        
    }

    public static void OnTimer(object source, ElapsedEventArgs e)
    {
        Total_Timer += Total_Timer;
        Timer theTimer = (Timer)source;
        theTimer.Interval += 1000;
        theTimer.Enabled = true;
    }


    
    private double calculateTime()
    {
        //Avg Time = Total Time / Total Sentences;
        return Total_Timer/6 ;/// 6
    }


    public void TaskOnClick()
    {
        if (typedText.text!="" && typedText.text != "Enter Text...")
        {
            OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Index, 0f, 0.5f, OVRInput.Controller.Active);
            if (textToEnter.text != typedText.text)
            {
                Err_Rate += 1;
            }
            if (index == 4)
            {
                buttons.text = "Submit";
                index += 1;
                textToEnter.text = textArray[index];
                typedText.text = "Enter Text...";
            }
            else if (index == 5)
            {
                Avg_timer.Stop();
                StartCoroutine(sendQualtricsData());
                SceneManager.LoadScene("QwertySceneController");
            }
            else
            {
                index += 1;
                textToEnter.text = textArray[index];
                typedText.text = "Enter Text...";
            }


        }

    }

    private double calculateError()
    {
        //Error Rate = Total Error / Total Time;
        return Err_Rate*100/6;
    }

   public IEnumerator sendQualtricsData()
    {
        WWWForm survey = new WWWForm();
       
        survey.AddField("PID", PID);
        survey.AddField("Scene_No", Scene_No);
        survey.AddField("Avg_Type_Time",calculateTime().ToString());
        survey.AddField("Avg_Error_Rate", calculateError().ToString());
        survey.AddField("User_Access_Rating", user_Rating);
        Debug.Log(url);
        UnityWebRequest form = UnityWebRequest.Post(url, survey);
        Debug.Log(form.ToString());
        //  Total_Timer = 0;
        //  Err_Rate=0;
        yield return form.SendWebRequest();
    }
}
