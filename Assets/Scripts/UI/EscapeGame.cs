using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeGame : MonoBehaviour{
   // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
}
