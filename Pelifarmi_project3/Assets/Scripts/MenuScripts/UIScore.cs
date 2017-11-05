using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScore : MonoBehaviour {
    private Text _text;
    private Score _score;
	// Use this for initialization
	void Awake () {
        _text = GetComponent<Text>();
        _score = GameObject.Find("ScoreManager").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_score == null)
        { _score = GameObject.Find("ScoreManager").GetComponent<Score>(); Debug.Log("Ei löydy scorea"); }
        if (_score != null)
        {
             int score = _score.GetCurrentScore();
             _text.text = "Score: " + score;
        }
        
	}
}
