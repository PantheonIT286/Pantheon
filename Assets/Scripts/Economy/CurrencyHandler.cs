using UnityEngine;
using TMPro;

public class CurrencyHandler : MonoBehaviour{
    // tower prices
        public int tower1Cost = 50;
        public int tower2Cost = 75;
        public int tower3Cost = 100;
        public int tower4Cost = 125;

    // spell prices
        public int spell1Cost = 50;
        public int spell2Cost = 75;
        public int spell3Cost = 100;
        public int spell4Cost = 125;

    // price display
        public TextMeshProUGUI towerPriceText;
        public TextMeshProUGUI spellPriceText;
    
    // reference to economy manager to manage gold currency
    public EconomyManager economyManager;

    // tracks the current cost of the tower or spell being purchased
        private int currentTowerCost;
        private int currentSpellCost;

    private bool canPurchase = false;

    // checks if the player has enough gold to purchase the tower and updates the canPurchase variable accordingly
    private void Update() {
        if (economyManager.gold > 0){
            canPurchase = true;
        } else {
            canPurchase = false;
        }
    }

    // sets the price text based on the tower type selected and updates the current tower cost
    public void setTowerPrice(int towerType){
        if (towerType == 1){
            towerPriceText.text = tower1Cost.ToString();
            currentTowerCost = tower1Cost;
        } else if (towerType == 2){
            towerPriceText.text = tower2Cost.ToString();
            currentTowerCost = tower2Cost;
        } else if (towerType == 3){
            towerPriceText.text = tower3Cost.ToString();
            currentTowerCost = tower3Cost;
        } else if (towerType == 4){
            towerPriceText.text = tower4Cost.ToString(); 
            currentTowerCost = tower4Cost;
        }
    }

    public void setSpellPrice(int spellType){
        if (spellType == 1){
            spellPriceText.text = spell1Cost.ToString();
            currentSpellCost = spell1Cost;
        } else if (spellType == 2){
            spellPriceText.text = spell2Cost.ToString();
            currentSpellCost = spell2Cost;
        } else if (spellType == 3){
            spellPriceText.text = spell3Cost.ToString();
            currentSpellCost = spell3Cost;
        } else if (spellType == 4){
            spellPriceText.text = spell4Cost.ToString(); 
            currentSpellCost = spell4Cost;
        }
    }

    // calls the economy manager to spend gold when a tower is purchased
    public void towerPurchase(){
        economyManager.SpendGold(currentTowerCost);
    }

    public void spellPurchase(){
        economyManager.SpendGold(currentSpellCost);
    }

    // returns whether the player can purchase the tower based on their current gold
    public bool getCanPurchase(){
        return canPurchase;
    }
}
