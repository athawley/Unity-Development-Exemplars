using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public Text timeText;
    private float timeExpired = 0;

    // Update is called once per frame
    void Update()
    {
        timeExpired += Time.deltaTime;
        DisplayTime(timeExpired);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
