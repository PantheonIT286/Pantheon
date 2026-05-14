using UnityEngine;
using TMPro;

public class InfoManager : MonoBehaviour{

    //public variables
        // references to the TextMeshProUGUI components for displaying information
            // tower information
            public TextMeshProUGUI towerNameTextResourcePanel;
            public TextMeshProUGUI towerNameTextOptionsPanel;
            public TextMeshProUGUI towerDescriptionTextResourcePanel;

            // game stats information
            public TextMeshProUGUI gameStatsTextResourcePanel;

            // spell information
            public TextMeshProUGUI spellNameTextResourcePanel;
            public TextMeshProUGUI spellDescriptionTextResourcePanel;

    // update the name and description of the TextMeshProUGUI components with the provided tower information
    public void UpdateTowerInfo(string towerName, string towerDescription){
        towerNameTextResourcePanel.text = towerName;
        towerDescriptionTextResourcePanel.text = towerDescription;
    }

    // update only the tower name in the TextMeshProUGUI component
    public void UpdateTowerInfo(string towerName){
        towerNameTextOptionsPanel.text = towerName;
    }

    // update game stats information in the TextMeshProUGUI component
    public void UpdateGameStatsInfo(string gameStatsInfo){
        gameStatsTextResourcePanel.text = gameStatsInfo;
    }

    // update the name and description of the TextMeshProUGUI components with the provided spell information
    public void UpdateSpellInfo(string spellName, string spellDescription){
        spellNameTextResourcePanel.text = spellName;
        spellDescriptionTextResourcePanel.text = spellDescription;
    }
}
