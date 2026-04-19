using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeGame : MonoBehaviour{
    // This function can be called by a UI button to quit the game or return to the main menu.  
    public void quitGame(){
        if (SceneManager.GetSceneByName("Easy").isLoaded){
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        } else {
            SceneManager.LoadScene("Menus");
        }
    }
}

