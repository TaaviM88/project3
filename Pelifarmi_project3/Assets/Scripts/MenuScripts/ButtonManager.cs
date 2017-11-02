﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

    public void LoadNewSceneBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
        Time.timeScale = 1;
    }
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
