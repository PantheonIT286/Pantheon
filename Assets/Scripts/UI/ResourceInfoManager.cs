using UnityEngine;

public class ResourceInfoManager : MonoBehaviour{
    //  public variables
        public InfoManager infoManager; // Reference to the TowersInfoManager script to manage tower information display

        public TowerHUDController towerHUDController; // Reference to the TowerHUDController script to manage tower selection and purchase actions

        public PlacementManager placementManager; // Reference to the PlacementManager script to manage tower placement actions

        public RTSCameraController rtsCameraController; // Reference to the RTS camera controller script to manage camera movement  
    
    // private variables
        private GameObject[] resourceInfoPanels; // Array to hold references to the resource info panels

        private GameObject towerSelected; // Variable to keep track of the currently selected tower

        private GameObject spellSelected; // Variable to keep track of the currently selected spell
        private EconomyManager economyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start(){
        // Initialize the resourceInfoPanels array with the child GameObjects of the parentGameObject
        resourceInfoPanels = new GameObject[transform.childCount];
        economyManager = FindFirstObjectByType<EconomyManager>();
        hideAllPanels(); // Call the method to hide all panels at the start
    }

    // manages the display of the tower information panel when a tower button is clicked
        public void TowersInfoPanel(GameObject towerButton){
            towerSelected = towerButton; // Store the reference to the currently selected tower button

            // Check the name of the tower button that was clicked and update the tower information accordingly
            if (towerButton.name == "Tower1"){
                // Update the tower information displayed in the panel using the TowersInfoManager
                infoManager.UpdateTowerInfo("Cannon Fort", "Shoots cannonballs at enemies, dealing heavy splash damage.");
            } else if (towerButton.name == "Tower2"){
                infoManager.UpdateTowerInfo("Archer Tower", "Shoots arrows at nearby enemies.");
            } else if (towerButton.name == "Tower3"){
                infoManager.UpdateTowerInfo("Wizard Tower", "Applies debuffs and status effects to enemies.");
            } else if (towerButton.name == "Tower4"){
                infoManager.UpdateTowerInfo("Knight Barrack", "Spawn knights within a restricted area that will attack nearby enemies.");
            }

            // Hide all panels before showing the tower information panel
            hideAllPanels();
            resourceInfoPanels[0].SetActive(!resourceInfoPanels[0].activeSelf);
        }

        public void TowersPurchaseButton(){
            if (towerSelected == null)
            {
                Debug.LogWarning("No tower selected for purchase.");
                return;
            }

            if (economyManager == null)
            {
                Debug.LogWarning("EconomyManager not found. Cannot purchase tower.");
                return;
            }

            if (!economyManager.TrySpendGold(economyManager.TowerPlacementCost))
            {
                Debug.Log("Not enough gold to purchase a tower.");
                return;
            }

            // Check the name of the tower button that was clicked and perform the purchase action accordingly
            if (towerSelected.name == "Tower1"){
                Debug.Log("Purchasing Tower 1");
                towerHUDController.SelectTower1();
            } else if (towerSelected.name == "Tower2"){
                Debug.Log("Purchasing Tower 2");
                towerHUDController.SelectTower2();
            } else if (towerSelected.name == "Tower3"){
                Debug.Log("Purchasing Tower 3");
                towerHUDController.SelectTower3();
            } else if (towerSelected.name == "Tower4"){
                Debug.Log("Purchasing Tower 4");
                towerHUDController.SelectTower4();
            }

            // Set the towerPurchased flag in the PlacementManager to allow tower placement after purchase
            placementManager.setTowerPurchased();

            // Hide all panels before performing the purchase action
            hideAllPanels();
        }

    
    // manages the display of the spell information panel when a spell button is clicked
        public void SpellsInfoPanel(GameObject spellButton){
            // Store the reference to the currently selected spell button
            spellSelected = spellButton;

            // Check the name of the tower button that was clicked and update the tower information accordingly
            if (spellButton.name == "Spell1"){
                infoManager.UpdateSpellInfo("Meteor Crash", "A giant meteor crashes onto the ground to deal massive damage, covering a wide radius.");
            } else if (spellButton.name == "Spell2"){
                infoManager.UpdateSpellInfo("Lightning Strikes", "A storm cloud forms to strike lightning, stunning and damaging enemies with minimal effort.");
            } else if (spellButton.name == "Spell3"){
                infoManager.UpdateSpellInfo("Gold Rush", "Earn double the gold from killing enemies for a brief period.");
            } else if (spellButton.name == "Spell4"){
                infoManager.UpdateSpellInfo("Tower Healing", " Restores the health of all towers within a certain radius.");
            }

            // Hide all panels before showing the spell information panel
            hideAllPanels();
            resourceInfoPanels[1].SetActive(!resourceInfoPanels[1].activeSelf);
        }

        public void SpellsPurchaseButton(){
            // Check the name of the spell button that was clicked and perform the purchase action accordingly
            if (spellSelected.name == "Spell1"){
                Debug.Log("Purchasing Spell 1");
            } else if (spellSelected.name == "Spell2"){
                Debug.Log("Purchasing Spell 2");
            } else if (spellSelected.name == "Spell3"){
                Debug.Log("Purchasing Spell 3");
            } else if (spellSelected.name == "Spell4"){
                Debug.Log("Purchasing Spell 4");
            }

            // Hide all panels before performing the purchase action
            hideAllPanels();
        }


    // manages the display of the game stats information panel when hovering over a game stats UI element
    public void GameStatsInfoPanel(GameObject gameStatsUI){
        // Check the name of the game stats UI element that was clicked and update the game stats information accordingly
        if (gameStatsUI.name == "Health"){
            infoManager.UpdateGameStatsInfo("Castle Health: ");
        } else if (gameStatsUI.name == "Currency"){
            infoManager.UpdateGameStatsInfo("Gold Amount: ");
        } else if (gameStatsUI.name == "Wave"){
            infoManager.UpdateGameStatsInfo("Wave Number: ");
        }

        // Hide all panels before showing the game stats panel
        hideAllPanels();
        resourceInfoPanels[2].SetActive(!resourceInfoPanels[2].activeSelf);
    }

    // manges the display of the tower options panel and its buttons when right-clicking on a tower
        public void TowerOptionsPanel(GameObject tower){
            // Store the reference to the currently selected tower
            towerSelected = tower;

            // Check the name of the selected tower and update the tower information displayed in the panel accordingly
            if (towerSelected.CompareTag("Tower1")){
                infoManager.UpdateTowerInfo("Cannon Fort");
            } else if (towerSelected.CompareTag("Tower2")){
                infoManager.UpdateTowerInfo("Archer Tower");
            } else if (towerSelected.CompareTag("Tower3")){
                infoManager.UpdateTowerInfo("Wizard Tower");
            } else if (towerSelected.CompareTag("Tower4")){
                infoManager.UpdateTowerInfo("Knight Barrack");
            }

            // Hide all panels before showing the tower options panel
            hideAllPanels();
            resourceInfoPanels[3].SetActive(!resourceInfoPanels[3].activeSelf);
        }

        public void SellTower(){
            // checks the name of the currently selected tower for debugging purposes
            if (towerSelected.CompareTag("Tower1")){
                Debug.Log("Selling Tower 1");
            } else if (towerSelected.CompareTag("Tower2")){
                Debug.Log("Selling Tower 2");
            } else if (towerSelected.CompareTag("Tower3")){
                Debug.Log("Selling Tower 3");
            } else if (towerSelected.CompareTag("Tower4")){
                Debug.Log("Selling Tower 4");
            }

            // Destroy the currently selected tower
            Destroy(towerSelected);

            // hide the tower options panel after selling the tower
            hideAllPanels();
        }

        public void TowerPossession(){
            // checks the name of the currently selected tower for debugging purposes
            if (towerSelected.CompareTag("Tower1")){
                Debug.Log("Possessing Tower 1");
            } else if (towerSelected.CompareTag("Tower2")){
                Debug.Log("Possessing Tower 2");
            } else if (towerSelected.CompareTag("Tower3")){
                Debug.Log("Possessing Tower 3");
            } else if (towerSelected.CompareTag("Tower4")){
                Debug.Log("Possessing Tower 4");
            }

             // hide the tower options panel after selling the tower
            hideAllPanels();

            // Attempt to possess the selected tower using the RTS camera controller
            rtsCameraController.TryPossess(towerSelected);
        }

    // Sets all panels in the resourceInfoPanels array to inactive (hidden)
    public void hideAllPanels(){
        for (int i = 0; i < resourceInfoPanels.Length; i++){
            resourceInfoPanels[i] = transform.GetChild(i).gameObject;
            resourceInfoPanels[i].SetActive(false);
        }
    }
}
