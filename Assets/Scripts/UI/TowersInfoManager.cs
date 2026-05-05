using UnityEngine;
using TMPro;

public class TowersInfoManager : MonoBehaviour{

    //public variables
        // References to the TextMeshProUGUI components for displaying tower information
        public TextMeshProUGUI towerNameText;
        public TextMeshProUGUI towerDescriptionText;

    // Update the text of the TextMeshProUGUI components with the provided tower information
    public void UpdateTowerInfo(string towerName, string towerDescription){
        towerNameText.text = towerName;
        towerDescriptionText.text = towerDescription;
    }
}
