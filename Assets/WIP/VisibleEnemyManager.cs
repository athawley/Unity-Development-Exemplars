using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleEnemyManager : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public Canvas enemyCanvas;

    public GameObject[] enemies;
    public GameObject[] enemyText;

    public GameObject enemyUIprefab;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyText = new GameObject[enemies.Length];
        foreach(GameObject enemy in enemies) {
            Debug.Log(enemy.GetInstanceID());
        }
        //cam = GetComponent<Camera>();

        // Get list of players
    }



    void Update()
    {
        //
        for(int i = 0; i < enemies.Length; i++) {
            Transform target = enemies[i].transform;
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            //Debug.Log(enemy + " target is " + screenPos.x + " pixels from the left");
            //Debug.Log(enemy + " target is " + screenPos.y + " pixels from the top");
            
            if(enemyText[i] == null) {
                
                enemyText[i] = Instantiate(enemyUIprefab, new Vector3(0,0,0), Quaternion.identity);

                enemyText[i].transform.Find("EnemyText").GetComponent<Text>().text = "" + enemies[i].GetInstanceID();
                
                enemyText[i].transform.SetParent(enemyCanvas.transform);

            }
            enemyText[i].transform.position = new Vector2(screenPos.x, screenPos.y);
            //enemyText[i].transform.position = new Vector2(0,0);
        }

        /*
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        
        
        if(go == null) {
        go = Instantiate(enemy)
        go.transform.SetParent(enemyCanvas.transform);
        Text myText = go.AddComponent<Text>();
        myText.text = go.ToString();
        myText.font = new Font("Serif");
        }
        
        go.transform.position = new Vector2(screenPos.x, screenPos.y);
        */
        
    }
}
