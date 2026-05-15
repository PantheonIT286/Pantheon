using UnityEngine;
using TMPro;

public class GameSpeed : MonoBehaviour{
    public TextMeshProUGUI speedText; // UI text component to track speed.

    // Gameobject components to set speed sprite.
        public GameObject speed1;
        public GameObject speed2;
        public GameObject speed3;

    // Sets game at normal speed
    private void Start(){
        speed1.SetActive(true);
        speed2.SetActive(false);
        speed3.SetActive(false);

        Time.timeScale = 1;
    }

    // Changes the game speed between normal, medium, and fast.
        public void mediumSpeed(){
            if (Time.timeScale == 1){
                Time.timeScale = 3;
                speedText.text = "2";

                speed1.SetActive(false);
                speed2.SetActive(true);
            } else{
                fastSpeed();
            }
        }

        private void fastSpeed(){
            if (Time.timeScale == 3){
                Time.timeScale = 5;
                speedText.text = "3";

                speed2.SetActive(false);
                speed3.SetActive(true);
            } else{
                normalSpeed(); 
            }
        }

        private void normalSpeed(){
            if (Time.timeScale != 0){
                Time.timeScale = 1;
                speedText.text = "1";

                speed3.SetActive(false);
                speed1.SetActive(true);
            }
        }
}