using UnityEngine;
using TMPro;

public class GameSpeed : MonoBehaviour{
    public TextMeshProUGUI speedText; // UI text component to display the current game speed.

    // Changes the game speed between normal, medium, and fast.
        public void mediumSpeed(){
            if (Time.timeScale == 1){
                Time.timeScale = 2;
                speedText.text = "Medium Speed";
            } else{
                fastSpeed();
            }
        }

        private void fastSpeed(){
            if (Time.timeScale == 2){
                Time.timeScale = 3;
                speedText.text = "Fast Speed";
            } else{
                normalSpeed(); 
            }
        }

        private void normalSpeed(){
            if (Time.timeScale != 0){
                Time.timeScale = 1;
                speedText.text = "Normal Speed";
            }
        }
}