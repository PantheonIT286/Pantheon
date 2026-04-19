using UnityEngine;
using UnityEngine.UI;

public class ResourceInfoManager : MonoBehaviour{
    //  public variables
        public TowersInfoManager towersInfoManager; // Reference to the TowersInfoManager script to manage tower information display

        public TowerHUDController towerHUDController; // Reference to the TowerHUDController script to manage tower selection and purchase actions
    
    // private variables
        private GameObject[] resourceInfoPanels; // Array to hold references to the resource info panels

        private GameObject towerSelected; // Variable to keep track of the currently selected tower button

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        // Initialize the resourceInfoPanels array with the child GameObjects of the parentGameObject
        resourceInfoPanels = new GameObject[transform.childCount];
        hideAllPanels(); // Call the method to hide all panels at the start

    }

    public void TowersInfoPanel(GameObject towerButton){
        // Hide all panels before showing the tower information panel
        hideAllPanels();
        resourceInfoPanels[0].SetActive(!resourceInfoPanels[0].activeSelf);

        towerSelected = towerButton; // Store the reference to the currently selected tower button

        // Check the name of the tower button that was clicked and update the tower information accordingly
        if (towerButton.name == "Tower1"){
            // Update the tower information displayed in the panel using the TowersInfoManager
            towersInfoManager.UpdateTowerInfo("Cannon Fort", "Shoots cannonballs at enemies that deal heavy splash damage.");
        } else if (towerButton.name == "Tower2"){
            towersInfoManager.UpdateTowerInfo("Archer Tower", "Shoots arrows at nearby enemies.");
        } else if (towerButton.name == "Tower3"){
            towersInfoManager.UpdateTowerInfo("Wizard Tower", "Applies debuffs/status effects to enemies.");
        } else if (towerButton.name == "Tower4"){
            towersInfoManager.UpdateTowerInfo("Knight Barrack", "Spawn knights that will attack nearby enemies. Knights are restricted to moving in a small field around the barrack.");
        }
    }

    public void TowersPurchaseButton(){
        hideAllPanels(); // Hide all panels before performing the purchase action

        // Check the name of the tower button that was clicked and perform the purchase action accordingly
        if (towerSelected.name == "Tower1"){
            // Call the method to purchase Tower 1
            Debug.Log("Purchasing Tower 1");
            towerHUDController.SelectTower1();
        } else if (towerSelected.name == "Tower2"){
            // Call the method to purchase Tower 2
            Debug.Log("Purchasing Tower 2");
            towerHUDController.SelectTower2();
        } else if (towerSelected.name == "Tower3"){
            // Call the method to purchase Tower 3
            Debug.Log("Purchasing Tower 3");
            towerHUDController.SelectTower3();
        } else if (towerSelected.name == "Tower4"){
            // Call the method to purchase Tower 4
            Debug.Log("Purchasing Tower 4");
            towerHUDController.SelectTower4();
        }
    }


    public void SpellsInfoPanel(){
        hideAllPanels();
        // Toggle the active state of the second panel (index 1) when the method is called
        resourceInfoPanels[1].SetActive(!resourceInfoPanels[1].activeSelf);
    }

    public void GameStatsInfoPanel(){
        hideAllPanels();
        // Toggle the active state of the third panel (index 2) when the method is called
        resourceInfoPanels[2].SetActive(!resourceInfoPanels[2].activeSelf);
    }

        // Sets all panels in the resourceInfoPanels array to inactive (hidden)
        public void hideAllPanels(){
            for (int i = 0; i < resourceInfoPanels.Length; i++){
                resourceInfoPanels[i] = transform.GetChild(i).gameObject;
                resourceInfoPanels[i].SetActive(false);
            }
        }
}
