using UnityEngine;

public class TowerOptions : MonoBehaviour{
    // public variables
        public ResourceInfoManager resourceInfoManager; // Reference to the ResourceInfoManager script to manage tower sell information display
    
    // private variables
        // reference to the strategy camera for raycasting
        private Camera strategyCamera;

    private void Start(){
        strategyCamera = CameraManager.Instance.strategyCamera.GetComponent<Camera>();
    }

    private void Update(){
        // creates a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // open the tower options panel when right-clicking on a tower if the game is not in possession mode
        if (Physics.Raycast(ray, out hit, 70f, LayerMask.GetMask("Tower")) && Input.GetMouseButtonDown(1)){
            resourceInfoManager.TowerOptionsPanel(hit.collider.gameObject); 
        }  
    }
}   
