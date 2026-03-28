using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour{
      public TextMeshProUGUI pauseText; // UI text component to display pause messages.

    // Pauses the game and activates the pause menu UI.
    public void Pause(){
      // Check if the game is currently running and toggle the pause state accordingly.
      if (Time.timeScale == 1){
         Time.timeScale = 0; 
         pauseText.text = "Resume";
      } else {
         Resume();
      }
   }


   // Resumes the game and deactivates the pause menu UI.
   void Resume(){
      // Check if the game is currently paused and toggle the resume state accordingly.
         if (Time.timeScale == 0){
            Time.timeScale = 1; 
            pauseText.text = "Pause";
         }  
   }
}