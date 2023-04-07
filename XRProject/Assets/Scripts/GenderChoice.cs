using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenderChoice : MonoBehaviour
{
    public TextMeshPro button;
    public static string selection;
    // Start is called before the first frame update
    void Start()
    {
        selection = "Male";
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
