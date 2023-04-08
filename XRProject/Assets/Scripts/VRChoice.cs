using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VRChoice : MonoBehaviour
{
    public TextMeshPro button;
    public GameObject nextButton;
    TextMeshPro selectedButton;
    Color normalColor;
    public static string selection = "";
    void Start()
    {
        selection = "None";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskOnClick()
    {
        nextButton.SetActive(true);
        if (selectedButton != null)
        {
            selectedButton.color = normalColor;
        }
        normalColor = button.color;
        button.color = Color.red;
        button.outlineWidth = 0.2f;
        button.outlineColor = Color.red;
        selection = button.text;
        selectedButton = button;
    }
}
