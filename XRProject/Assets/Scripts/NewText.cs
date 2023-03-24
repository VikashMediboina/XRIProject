using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NewText : MonoBehaviour
{
    // Start is called before the first frame update
     public TextMeshPro textComponent; 
     public GameObject EnableInteractable;
    void Start()
    {
       
    }

    public void NewTextEntry(TextMeshPro value){
        if(EnableInteractable.GetComponent<EnableInteractable>().acessClick()){
 if(textComponent.text=="Enter Text..."){
            textComponent.text="";
        }
        else if(textComponent.text==""){
            textComponent.text="Enter Text...";
        }
        if(value.text=="Space"){
            textComponent.text+=" ";
        }
        else if(value.text=="Clear"){
            textComponent.text=textComponent.text.Remove(textComponent.text.Length-1,1);
        }
        else{
        textComponent.text+=value.text;
        }

        EnableInteractable.GetComponent<EnableInteractable>().resetClick();
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
