using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BALListicsGameManager : MonoBehaviour
{
    public static BALListicsGameManager Instance { get; private set; }
    public int matchLengthSeconds = 90;
    public int redScore = 0;
    public int blueScore = 0;
    public int goalPoints = 1;

    public Text timerText;
    public Text redScoreText;
    public Text blueScoreText;

    private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
}

    IEnumerator gameTimer;

    IEnumerator playGame(int time) {
        int minutes, seconds;
        minutes = matchLengthSeconds / 60;
        seconds = matchLengthSeconds % 60;
        timerText.text = minutes + ":" + seconds;

        while(time >= 0) {
            yield return new WaitForSeconds(1);
            time = time - 1;
            minutes = time / 60;
            seconds = time % 60;
            timerText.text = minutes + ":" + seconds;
        }

        // Stop game
        StopCoroutine(gameTimer);
    }

    public void scoreTeam(string t) {
        if(t == "red") {
            redScore = redScore + goalPoints;
            redScoreText.text = "" + redScore;
        }
        if(t == "blue") {
            blueScore = blueScore + goalPoints;
            blueScoreText.text = "" + blueScore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blueScoreText.text = "" + blueScore;
        redScoreText.text = "" + redScore;
        gameTimer = playGame(matchLengthSeconds);
        StartCoroutine(gameTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
