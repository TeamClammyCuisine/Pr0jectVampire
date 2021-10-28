using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void OnLeaveClick()
    {
        Debug.Log("Clicked Leave");
        Application.Quit();
    }
    
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
