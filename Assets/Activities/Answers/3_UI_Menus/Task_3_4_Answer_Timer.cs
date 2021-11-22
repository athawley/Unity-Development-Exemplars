using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task_3_4_Answer_Timer : MonoBehaviour
{
    
    [SerializeField] GameObject player;
    [SerializeField] Slider livesSlider;
    [SerializeField] Text timerText;
    public float lives = 3;
    public float startTime = 10;

    void Start()
     {
         StartCoroutine (GameTimer());    
         timerText.text = "" + startTime;
         livesSlider.value = lives;
     }

     public void LoseLife() {
         lives = lives - 1;
         livesSlider.value = lives;
         if(lives <=0) {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
     }
     
     IEnumerator GameTimer()
     {
        while(true) 
        { 
            startTime = startTime - 1;
            if(startTime <= 0) {
                timerText.text = "Game Over";
                //Time.timeScale = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            }
            timerText.text = "" + startTime;

            yield return new WaitForSeconds(1f);
        }
     }
}
