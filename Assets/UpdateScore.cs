using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {
    public Toggle toggle;
    public Text scoreText;
    public int score ;
    public bool onVibration;
    private int vibrationTrue;
	// Use this for initialization
	void Start () {
        vibrationTrue = PlayerPrefs.GetInt("vibrationOn");
        if(vibrationTrue==1)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        

	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("vibrationOn", vibrationTrue);
        if (toggle.isOn)
        {
            onVibration = true;
            vibrationTrue = 1;
        
        }
        else
        {
            onVibration = false;
            vibrationTrue = 0;
        }
        
	}

    public void Save()
    {
        Serialize.SaveScore(this);
    }

    public void Load()
    {
        int LoadedScore = Serialize.LoadScore();
        score = LoadedScore;

    }


    public void Vibrate()
    {
        if(onVibration == true)
        {
            Handheld.Vibrate();
        }
        
    }

    public void Score(){
        score++;

    }
}
