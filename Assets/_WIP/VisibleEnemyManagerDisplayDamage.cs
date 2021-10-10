using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleEnemyManagerDisplayDamage : MonoBehaviour
{
    public Camera cam; // The camera used as a viewport to view the enemies
    public Canvas enemyCanvas; // UI Canvas for displaying enemy UI elements onto.

    public GameObject[] enemies; // Array of enemy gameobjects
    public GameObject[] enemyUIForPlayer; // Prefab array for UI elements for each enemy object.

    public GameObject enemyUIprefab; // Prefab containing the default enemyUI prefab

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Get array of all objects tagged with Enemy
        enemyUIForPlayer = new GameObject[enemies.Length]; // Get UI array to number of enemy objects
    }

    void Update()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Get array of all objects tagged with Enemy
        // Go through each enemy object to determine if it is visible or not
        bool totalEnemiesChanged = false;
        for(int i = 0; i < enemies.Length; i++) {
            if(enemies[i] == null) {
                //Destroy(enemyUIForPlayer[i]);
                //enemyUIForPlayer[i] = null;
                totalEnemiesChanged = true;
                continue;
            }
            // Display / Update the Enemy UI and assign it into the array to store to aid memory usage.
            enemyUIForPlayer[i] = DisplayEnemyUI(enemies[i], enemyUIForPlayer[i]);
        }
        if(totalEnemiesChanged) {
            enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Get array of all objects tagged with Enemy
            for(int i = 0; i < enemyUIForPlayer.Length; i++) {
                Destroy(enemyUIForPlayer[i]);
            }
            enemyUIForPlayer = new GameObject[enemies.Length]; // Get UI array to number of enemy objects
        }
    }

    GameObject DisplayEnemyUI(GameObject enemy, GameObject enemyUI) {
        Transform target = enemy.transform; // The position of the enemy in the world x,y,z
        /* Convert the object to a position in relation to the camera. x,y start bottom left of camera.
         * Positive z value is in front of the camera negative is behind.
         */
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
    
        // Check if the object is on the screen and in front of the camera
        if(screenPos.z >=0 && screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height) {
            //Debug.Log(enemy.GetInstanceID() + " - On Screen x:" + screenPos.x + " : y:" + screenPos.y); // Debug display
        
            // If the enemy UI hasn't been created create it.
            if(enemyUI == null) {
                
                enemyUI = Instantiate(enemyUIprefab, new Vector3(0,0,0), Quaternion.identity);

                // Update display text for the object
                enemyUI.transform.Find("EnemyText").GetComponent<Text>().text = "" + enemy.ToString();

                // Update the health
                Debug.Log(enemy.GetComponent<CharacterActions>().health);
                enemyUI.transform.Find("EnemyHealth").GetComponent<Slider>().value = enemy.GetComponent<CharacterActions>().health;
                
                enemyUI.transform.SetParent(enemyCanvas.transform); // Link it to the display canvas.

            }
            enemyUI.transform.Find("EnemyHealth").GetComponent<Slider>().value = enemy.GetComponent<CharacterActions>().health;
            enemyUI.SetActive(true); // Make active, used when object returns to being visible
            enemyUI.transform.position = new Vector2(screenPos.x, screenPos.y + 100); // Position on the canvas.
        } else {
            if(enemyUI == null) return null; // If no UI element skip.
                
            //Debug.Log(enemy.GetInstanceID() + " - Off Screen"); // Displays if object is off screen
            enemyUI.SetActive(false); // If off screen do not display
        
        }
        return enemyUI;
    }
}
