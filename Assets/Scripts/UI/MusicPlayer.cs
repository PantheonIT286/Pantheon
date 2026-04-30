using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour{
    public AudioSource musicAudio; // Audio component to play music

    // GameObject component to set music sprite
    public GameObject musicOn;
    public GameObject musicOff;


    // sets icon to musicOn sprite
    private void Start(){
        musicOn.SetActive(false);
        musicOff.SetActive(true);
    }
    
    // ensures music stops playing
    public void stopMusic() {
        if (musicAudio.isPlaying) {
            musicAudio.Stop();
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        } else {
            playMusic();
        }
    }

    // ensures music starts playing
    private void playMusic(){
        musicAudio.Play();
        musicOn.SetActive(true);
        musicOff.SetActive(false);
    }
}
