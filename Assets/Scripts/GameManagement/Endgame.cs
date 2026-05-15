using UnityEngine;

public class Endgame : MonoBehaviour{
    public WaveSpawner waveSpawner;
    public CastleHealth castleHealth;
    public MusicPlayer musicPlayer;


    public GameObject victoryScreen;

    public AudioSource victoryMusic;


    public GameObject gameOverScreen;
    public AudioSource gameOverMusic;


    private bool winState = false;
    private bool loseState = false;


    private bool continueUpdate = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (waveSpawner.waves.Count == waveSpawner.getCurrentWaveIndex() && GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
            winState = true;
        } else if (castleHealth.health <= 0){
            loseState = true;
        }
        
        if (winState && continueUpdate){
            WinState();
        } else if (loseState && continueUpdate){
            LoseState();
        }
    }

    private void WinState(){
        Time.timeScale = 0f;

        victoryScreen.SetActive(true); 

        victoryMusic.Play();
        musicPlayer.musicAudio.Stop();

        continueUpdate = false;
    }

    private void LoseState(){
        Time.timeScale = 0f;

        gameOverScreen.SetActive(true);
        
        gameOverMusic.Play();
        musicPlayer.musicAudio.Stop();

        continueUpdate = false;
    }
}
