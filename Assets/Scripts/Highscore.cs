using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text score;

    void OnEnable()
    {
        score.GetComponent<Text>();
        score.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
}
