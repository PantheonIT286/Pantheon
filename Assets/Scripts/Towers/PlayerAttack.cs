using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 25f;
    public int damage = 20;
    public float attackCooldown = 0.6f;

    private float lastAttackTime;

    private InputSystem_Actions inputActions;
    private Camera fpsCamera;

    [Header("UI")]
    public TextMeshProUGUI cooldownText;

    private void Awake()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager not found!");
            return;
        }

        inputActions = InputManager.Instance.InputActions;
        fpsCamera = GetComponent<Camera>();

        if (fpsCamera == null)
        {
            Debug.LogError("PlayerAttack requires a Camera component.");
        }
    }

    private void OnEnable()
    {
        inputActions.FPS.Attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        inputActions.FPS.Attack.performed -= OnAttack;
    }

    private void Update()
    {
        UpdateCooldownUI();
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        if (GameStateManager.Instance.CurrentState != GameState.PossessionMode)
            return;

        if (Time.time - lastAttackTime < attackCooldown)
            return;

        lastAttackTime = Time.time;

        FireRaycast();
    }

    private void FireRaycast()
    {
        Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);

        // Draw debug ray so you can see shots in Scene view
        Debug.DrawRay(ray.origin, ray.direction * attackRange, Color.red, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, attackRange))
        {
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Hit enemy: " + hit.collider.name);
            }
        }
    }

    private void UpdateCooldownUI()
    {
        if (cooldownText == null)
            return;

        float timeSinceLastAttack = Time.time - lastAttackTime;
        float remainingCooldown = attackCooldown - timeSinceLastAttack;

        if (remainingCooldown > 0)
        {
            cooldownText.text = "Cooldown: " + remainingCooldown.ToString("F1");
            cooldownText.color = Color.red;
        }
        else
        {
            cooldownText.text = "Attack Ready";
            cooldownText.color = Color.green;
        }
    }
}