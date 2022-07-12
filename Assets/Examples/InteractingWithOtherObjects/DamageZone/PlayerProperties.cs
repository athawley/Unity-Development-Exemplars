using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 1. 
Added the scene management for reloading the scene on death
This is used just for testing.
*/
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    // 2. Player Health
    public float health = 100;
    // 3. Max player health (not used)
    public float maxHealth = 100;
    // 4. player armour (not used)
    public float armour = 50;
    // 5. Max player armour (not used)
    public float maxArmour = 100;
    // 6. The player name (not used)
    public string name = "Pete the Player";

    // Update is called once per frame
    void Update()
    {
        // 7. Check if out of health
        if(health <= 0) {
            // 8. Reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
