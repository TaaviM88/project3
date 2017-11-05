using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private int _score = 0;
	// Use this for initialization
    public void AddScore(int amount)
    {
        Debug.Log(_score + "Pisteitä lisätty");
        _score += amount;
    }
	
	// Update is called once per frame
    public int GetCurrentScore()
    {
        return _score;
    }
}
