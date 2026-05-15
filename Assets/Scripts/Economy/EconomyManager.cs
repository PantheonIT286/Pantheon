using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour {
    public int gold = 100;
    public TextMeshProUGUI currencyText;
    
    // sets up the initial gold amount 
    private void Start(){
        Debug.Log("<color=yellow>Game Started. Current Gold:</color> " + gold);
        currencyText.text = gold.ToString();
    }

    // adds the specified amount of gold to the player's current gold amount
    public void AddGold(int amount){
        gold += amount;
        Debug.Log("<color=yellow>Gained Gold! Current Gold:</color> " + gold);
        currencyText.text = gold.ToString();
    }


    // checks if the player has enough gold to spend and deducts the specified amount from the player's current gold amount
    public void SpendGold(int amount){
        if (gold >= amount){
            gold -= amount;
            Debug.Log("<color=yellow>Spent Gold! Current Gold:</color> " + gold);
            currencyText.text = gold.ToString();
        } else {
            Debug.Log("<color=red>Not enough gold to spend!</color>");
        }
    }
}