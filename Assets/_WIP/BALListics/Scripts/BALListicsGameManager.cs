using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BALListicsGameManager : MonoBehaviour
{
    public PlayerInputManager pim;
    public static BALListicsGameManager Instance { get; private set; }
    public int matchLengthSeconds = 90;
    public int redScore = 0;
    public int blueScore = 0;
    public int goalPoints = 1;

    public Text timerText;
    public Text redScoreText;
    public Text blueScoreText;

    public static List<GameObject> players = new List<GameObject>();
    //public List<Transform> spawnLocations = new List<Transform>();
    

    void Start() {
        
        matchLengthSeconds = UIManager.Instance.gameLength;
        
    }

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
            string tmp = minutes + ":";
            if(seconds < 10) {
                tmp = tmp + "0" + seconds;
            } else {
                tmp = tmp + seconds;
            }
            timerText.text = tmp;
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

    public void SetupGame() {
        blueScoreText.text = "" + blueScore;
        redScoreText.text = "" + redScore;
        gameTimer = playGame(matchLengthSeconds);
        StartCoroutine(gameTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayers(List<Transform> locations) {
        Debug.Log("Attempting spawn all");
        //int spawnPointIndex = Random.Range (0, locations.Count);

        //PlayerInputManager
        
        foreach(GameObject p in BALListicsGameManager.players) {
            Debug.Log("Attempting spawn");
            int spawnPointIndex = Random.Range (0, locations.Count);
            p.GetComponent<BALListicsPlayerManager>().spawnPoint = locations[spawnPointIndex];
            p.GetComponent<BALListicsPlayerManager>().RespawnPlayer();
        }
    }

    public void RespawnItem(GameObject go) {
        int index = Random.Range(0,this.GetComponent<ArenaStart>().spawnLocations.Count);
        go.SetActive(false);
        go.transform.position = this.GetComponent<ArenaStart>().spawnLocations[index].transform.position;
        go.SetActive(true);
    }

    public void CheckReady() {
        // If all players have a team set to red or blue play the game.
        bool play = true;
        foreach(GameObject p in players) {
            if(p.GetComponent<BALListicsPlayerManager>().team == "None") {
                play =  false;
            }
        }
        if(play) {
            UIManager.Instance.LoadScene("Arena");
        }
    }
}
