using UnityEngine;
using TMPro;

public class GameSpeed : MonoBehaviour{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI speedText;

    public void fastSpeed(){
        if (Time.timeScale == 1){
            Time.timeScale = 2.0f;
            speedText.text = "Fast Speed";
        } else{
            normalSpeed();
        }
    }

    private void normalSpeed(){
        Time.timeScale = 1;
        speedText.text = "Normal Speed";
    }
}
