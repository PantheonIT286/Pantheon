using UnityEngine;

[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public InputSystem_Actions InputActions { get; private set; }

    private void Awake()
    {
        Debug.Log("InputManager Awake: " + gameObject.GetInstanceID());

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InputActions = new InputSystem_Actions();

        InputActions.Enable();
    }
}