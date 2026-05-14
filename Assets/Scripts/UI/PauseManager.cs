using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour{
   public TextMeshProUGUI speedText; // UI text component to check the current game speed.
   public WaveSpawner waveSpawner; // Reference to the WaveSpawner script to check the current wave status.

   // GameObject component to set pause/resume sprite
      public GameObject pause;
      public GameObject resume;

   // Ensures resume sprite is set at first load
   public void Start(){
      setPause();
   }

    // Pauses the game and activates the pause menu UI.
    public void Pause(){
      // Check if the game is currently running and toggle the pause state accordingly.
      if (Time.timeScale >= 1 && waveSpawner.IsSpawning() == true){
         Time.timeScale = 0; 
         pause.SetActive(true);
         resume.SetActive(false);
      } else {
         Resume();
      }
   }


   // Resumes the game and deactivates the pause menu UI.
   private void Resume(){
      // Check the current game speed and set the time scale accordingly when resuming the game.
         if (Time.timeScale == 0){
            if (speedText.text == "1"){
               Time.timeScale = 1; 
               setResume();
            } else if (speedText.text == "2"){
               Time.timeScale = 2; 
               setResume();
            } else if (speedText.text == "3"){
               Time.timeScale = 3; 
               setResume();
            }
         }  
   }

   // Utility methods to set the appropriate sprite for the pause and resume states.
      public void setResume(){
         pause.SetActive(false);
         resume.SetActive(true);
      }

      public void setPause(){
         pause.SetActive(true);
         resume.SetActive(false);
      }
}