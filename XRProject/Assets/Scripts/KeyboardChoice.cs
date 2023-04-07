using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyboardChoice : MonoBehaviour
{
    public TextMeshPro button;
    TextMeshPro selectedButton;
    Color normalColor;
    public static string selection="";

    // Start is called before the first frame update
    void Start()
    {
        selection = "Spherical Keyboard";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void taskOnClick()
    {
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
