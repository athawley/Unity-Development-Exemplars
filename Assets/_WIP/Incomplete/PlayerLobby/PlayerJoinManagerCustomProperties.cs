using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerLobbyExample {
public class PlayerJoinManagerCustomProperties : MonoBehaviour
{
   string[] names = {"Straven", "Caddick", "Hadlee", "Pomare", "Sutton", "Caldwell", "Deans"};
    // Start is called before the first frame update
   void OnPlayerJoined(PlayerInput pi) {
      Debug.Log("PlayerInput Joined " + pi.playerIndex);
      pi.gameObject.GetComponent<PlayerMovementCine3rdLocalMP>().CinemachineInputProvider.PlayerIndex = pi.playerIndex;

      

      // Select colour of player based on player index. (Team)
      // Even = blue
      // Odd = Black
      PlayerSettings ps = new PlayerSettings();
      ps.PlayerIndex = pi.playerIndex;
      ps.SecondaryColour = Color.white;

      // Create a Random object index for the name
      int pos = Random.Range(0, names.Length);
      
      if(pi.playerIndex %2 == 0) {
         ps.TeamName = "Black";
         ps.MainColour = Color.black;
         ps.PlayerName = "[Black]" + pi.playerIndex + names[pos];
      } else {
         ps.TeamName = "Blue";
         ps.MainColour = Color.blue;
         ps.PlayerName = "[Black]" + pi.playerIndex + names[pos];
      }

      pi.gameObject.GetComponent<PlayerPropertiesManager>().ConfigurePlayer(ps);
   }

    
}

}