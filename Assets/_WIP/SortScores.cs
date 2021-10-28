using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SortScores : MonoBehaviour
{
    public List<PlayerResult> unsortedScores = new List<PlayerResult>();
    public void Start() {
        Sort();
    }
    public void Sort() {
        PlayerResult p1 = new PlayerResult("A", 5);
        unsortedScores.Add(p1);
        PlayerResult p2 = new PlayerResult("B", 3);
        unsortedScores.Add(p2);
        PlayerResult p3 = new PlayerResult("C", 7);
        unsortedScores.Add(p3);
        PlayerResult p4 = new PlayerResult("D", 3);
        unsortedScores.Add(p4);

        Debug.Log("Unsorted");
        foreach(PlayerResult p in unsortedScores) {
            Debug.Log(p.playerName + " " + p.playerScore);
        }

        unsortedScores.Sort((s1, s2) => s2.playerScore.CompareTo(s1.playerScore));

        Debug.Log("Sorted");
        foreach(PlayerResult p in unsortedScores) {
            Debug.Log(p.playerName + " " + p.playerScore);
        }
    }
}

public struct PlayerResult {
    public string playerName;
    public int playerScore;

    public PlayerResult(string n, int s) {
        playerName = n;
        playerScore = s;
    }
}