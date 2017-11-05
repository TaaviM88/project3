using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    private static UI _current;
    public static UI Current
    {
        get { return _current; }
    }
    private UIGameOver _gameover;
	// Use this for initialization
	private void Awake () {
        _current = this;
        _gameover = GetComponentInChildren<UIGameOver>(true);
	}
	
	// Update is called once per frame
    public void ShowGameOver()
    {
        _gameover.Show();
    }
}
