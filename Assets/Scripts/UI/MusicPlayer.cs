using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour{
    public AudioSource musicAudio;
    public TextMeshProUGUI musicText;

    private void Start(){
        musicText.text = "Music Off";
    }
    
    public void playMusic() {
        if (musicAudio.isPlaying) {
            musicAudio.Stop();
            musicText.text = "Music Off";

        } else {
            stopMusic();
        }
    }

    private void stopMusic(){
        musicAudio.Play();
        musicText.text = "Music On";
    }
}
