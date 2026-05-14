using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // DifficultyScale values: 1 = easy, 3 = medium, 10 = hard
    public int DifficultyScale { get; set; } = 1;

    public int Level { get; set; } = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
