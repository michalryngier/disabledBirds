﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{    
    public string sceneName;
    
    public void ChangeToScene()
    {
        if (String.IsNullOrEmpty(sceneName) == false) {
            SceneManager.LoadScene(sceneName);
        }
    }
}