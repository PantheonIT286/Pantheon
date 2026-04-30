using UnityEngine;
using UnityEngine.InputSystem;

public class GameSpeedController : MonoBehaviour
{
    public float slowSpeed = 0.5f;
    public float normalSpeed = 1f;
    public float fastSpeed = 2f;

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SetSpeed(slowSpeed);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SetSpeed(normalSpeed);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SetSpeed(fastSpeed);
        }
    }

    void SetSpeed(float speed)
    {
        Time.timeScale = speed;
        Debug.Log("Game speed set to: " + speed);
    }
}