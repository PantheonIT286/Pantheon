using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour{
      public TextMeshProUGUI pauseText; // UI text component to display pause messages.
      public TextMeshProUGUI speedText; // UI text component to check the current game speed.

    // Pauses the game and activates the pause menu UI.
    public void Pause(){
      // Check if the game is currently running and toggle the pause state accordingly.
      if (Time.timeScale >= 1){
         Time.timeScale = 0; 
         pauseText.text = "Resume";
      } else {
         Resume();
      }
   }


   // Resumes the game and deactivates the pause menu UI.
   void Resume(){
      // Check the current game speed and set the time scale accordingly when resuming the game.
         if (Time.timeScale == 0){
            if (speedText.text == "Normal Speed"){
               Time.timeScale = 1; 
               pauseText.text = "Pause";
            } else if (speedText.text == "Medium Speed"){
               Time.timeScale = 2; 
               pauseText.text = "Pause";
            } else if (speedText.text == "Fast Speed"){
               Time.timeScale = 3; 
               pauseText.text = "Pause";
            }
         }  
   }
}