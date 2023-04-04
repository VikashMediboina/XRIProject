using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SceneSelector : MonoBehaviour
{
    public string endScene;
    static string[] sceneNames= { "QwertySceneController" , "QwertyScenePoke", "SphericalSceneController", "SphericalScenePoke" };
    static int randIndex;
    private static int currentIndex = -1;

    void Start()
    {
        //// Shuffle the scene names array
        //for (int i = 0; i < sceneNames.Length; i++)
        //{
        //    string temp = sceneNames[i];
        //    int randomIndex = Random.Range(i, sceneNames.Length);
        //    sceneNames[i] = sceneNames[randomIndex];
        //    sceneNames[randomIndex] = temp;
        //}
    }

    public void LoadNextScene()
    {
        randIndex= Random.Range(0, sceneNames.Length);
        currentIndex++;

        if (currentIndex >= sceneNames.Length)
        {
            SceneManager.LoadScene(endScene);
        }
        else
        {
            SceneManager.LoadScene(sceneNames[randIndex]);
        }
    }
}
