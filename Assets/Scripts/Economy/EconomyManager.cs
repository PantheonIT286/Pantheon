using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour 
{
    public int gold = 100;
    public TextMeshProUGUI currencyText;
    
    void Start()
    {
        Debug.Log("<color=yellow>Game Started. Current Gold:</color> " + gold);
        currencyText.text = gold.ToString();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("<color=yellow>Gained Gold! Current Gold:</color> " + gold);
        currencyText.text = gold.ToString();
    }
}