using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGameOver : MonoBehaviour
{
    private Text _text;
    private void Awake()
    {
        _text = GetComponentInChildren<Text>(true);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        string text = "Game Over!";
        _text.text = text;
        gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
