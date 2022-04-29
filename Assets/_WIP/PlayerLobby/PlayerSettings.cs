using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLobbyExample {

public struct PlayerSettings {
   public Color MainColour;
   public Color SecondaryColour;
   public int PlayerIndex;
   public string PlayerName;
   public int PlayerPoints;
   public int PlayerDeaths;
   public string TeamName;

   public string Role;

   public float Speed, Mass, Width, Height;
}

}