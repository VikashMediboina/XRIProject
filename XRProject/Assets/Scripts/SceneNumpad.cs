using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneNumpad : MonoBehaviour
{
    public TextMeshPro button;
    public static string selection;
    // Start is called before the first frame update
    void Start()
    {
        selection = "9";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskOnClick()
    {
        selection = button.text;
    }
}
