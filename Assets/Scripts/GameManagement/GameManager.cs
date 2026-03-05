using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //1 3 10 easy med hard
    public int DifficultyScale { get; set; } = 1;
    public int Gold { get; set; } = 0;
    public int Level { get; set; } = 1;

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
} 