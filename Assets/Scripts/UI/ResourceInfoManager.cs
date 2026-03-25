using UnityEngine;

public class ResourceInfoManager : MonoBehaviour{
    //public variables
        private GameObject[] resourceInfoPanels; // Array to hold references to the resource info panels


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        // Initialize the resourceInfoPanels array with the child GameObjects of the parentGameObject
        resourceInfoPanels = new GameObject[transform.childCount];
        hideAllPanels(); // Call the method to hide all panels at the start

    }


    // Update is called once per frame
    void Update(){
        
    }


    public void TowersInfoPanel(){
        hideAllPanels();
        // Toggle the active state of the first panel (index 0) when the method is called
        resourceInfoPanels[0].SetActive(!resourceInfoPanels[0].activeSelf);
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

    //private methods
        // Sets all panels in the resourceInfoPanels array to inactive (hidden)
        public void hideAllPanels(){
            for (int i = 0; i < resourceInfoPanels.Length; i++){
                resourceInfoPanels[i] = transform.GetChild(i).gameObject;
                resourceInfoPanels[i].SetActive(false);
            }
        }
}
