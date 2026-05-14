using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }

    public int gold = 100;
    public TextMeshProUGUI currencyText;
    [SerializeField] private int towerPlacementCost = 500;
    [SerializeField] private int unitPlacementCost = 20;
    [SerializeField] private int enemyKillReward = 3;
    [SerializeField] private float killRewardMultiplier = 1f;

    public int TowerPlacementCost => towerPlacementCost;
    public int UnitPlacementCost => unitPlacementCost;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogWarning("Multiple EconomyManager instances found.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("<color=yellow>Game Started. Current Gold:</color> " + gold);
        RefreshCurrencyText();
    }

    public void AddGold(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("AddGold called with non-positive amount: " + amount);
            return;
        }

        gold += amount;
        Debug.Log("<color=yellow>Gained Gold! Current Gold:</color> " + gold);
        RefreshCurrencyText();
    }

    public bool TrySpendGold(int amount)
    {
        if (amount == 0) return true;
        if (amount < 0)
        {
            Debug.LogWarning("TrySpendGold called with negative amount: " + amount);
            return false;
        }
        if (gold < amount) return false;

        gold -= amount;
        Debug.Log("<color=yellow>Spent Gold! Current Gold:</color> " + gold);
        RefreshCurrencyText();
        return true;
    }

    public void AddEnemyKillGold()
    {
        int reward = Mathf.RoundToInt(enemyKillReward * killRewardMultiplier);
        if (reward > 0)
        {
            AddGold(reward);
        }
    }

    private void RefreshCurrencyText()
    {
        if (currencyText != null)
        {
            currencyText.text = gold.ToString();
        }
    }
}
