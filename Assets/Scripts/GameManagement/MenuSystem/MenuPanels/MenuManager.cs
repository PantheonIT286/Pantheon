using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;

// This script is responsible for managing menu behavior and interactivity.
public class MainMenuInteractivity : MonoBehaviour{
    // References to the menus visual elements in the UI document.
    private VisualElement mainMenu;
    private VisualElement storyMenu;
    private VisualElement optionsMenu;

    // References to the startup/exit buttons in the main menu visual element.
    private Button startButton;
    private Button quitButton;

    // Reference to the confirmation button in the story menu visual element.
    private Button AcceptButton;

    // References to the difficulty buttons in the options menu visual element.
    private Button easyButton;
    private Button mediumButton;
    private Button hardButton;
    
    // Called when the script instance is being loaded. Initializes the menu system and configures the initial menu state.
    private void Awake(){
        // Get the root visual element of the UI document to set up event listeners and manage UI interactions.
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        // Query the menus visual elements from the root visual element of the UI document.
        mainMenu = root.Q<VisualElement>("mainMenu");
        storyMenu = root.Q<VisualElement>("storyMenu");
        optionsMenu = root.Q<VisualElement>("optionsMenu");

        // Query the startup/exit buttons from the main menu visual element.
        startButton = root.Q<Button>("Start");
        quitButton = root.Q<Button>("Quit");

        // Query the confirmation button from the story menu visual element.
        AcceptButton = root.Q<Button>("Accept");

        // Query the difficulty buttons from the options menu visual element.
        easyButton = root.Q<Button>("Easy");
        mediumButton = root.Q<Button>("Medium");
        hardButton = root.Q<Button>("Hard");

        // Set the initial visibility of the main menu and hide the story and options menus.
        Debug.Log("Initializing main menu...");
        mainMenu.style.display = DisplayStyle.Flex;
        storyMenu.style.display = DisplayStyle.None;
        optionsMenu.style.display = DisplayStyle.None;

        // Method call to begin button event setups.
        MainMenuButtonEvents();
    }

    // Set up event listeners for the buttons in the main menu to handle user interactions when clicked.
    private void MainMenuButtonEvents(){
        // Set up an event listener for the "Start" button to switch to the story menu when clicked.
        if (startButton != null)
            startButton.clicked += () => {
                Debug.Log("Start button clicked!");
                SwitchMenu(storyMenu, mainMenu);
                StoryMenuButtonEvents();
                };
        else
            Debug.LogError("Start button not found in the UI document.");

        // Set up an event listener for the "Quit" button to exit the application when clicked.
        if (quitButton != null)
            quitButton.clicked += () => {
                Debug.Log("Quit button clicked!");
                Debug.Log("Exiting game...");
                Application.Quit();
                EditorApplication.isPlaying = false; // Stop play mode in the Unity Editor when the quit button is clicked.
            };
        else            
            Debug.LogError("Quit button not found in the UI document.");
        }


    // Set up event listener for the button in the story menu to handle user interactions when clicked.
    private void StoryMenuButtonEvents(){
        // Set up an event listener for the "Accept" button to switch to the options menu when clicked
        AcceptButton.clicked += () => {
            Debug.Log("Accept button clicked!");
            SwitchMenu(optionsMenu, storyMenu);
            OptionsButtonEvents();
        };
    }


    // Set up event listeners for the buttons in the options menu to handle user interactions when clicked.
    private void OptionsButtonEvents(){
        // Set up event listeners for the difficulty buttons to handle user interactions when clicked.
        if (easyButton != null)
            easyButton.clicked += () => {
                Debug.Log("Easy button clicked!");
                SceneManager.LoadScene("Easy");
                GameManager.Instance.DifficultyScale = 1; 

            };
        else
            Debug.LogError("Easy button not found in the UI document.");


        if (mediumButton != null)
            mediumButton.clicked += () => {
                Debug.Log("Medium button clicked!");
                SceneManager.LoadScene("Medium");
                GameManager.Instance.DifficultyScale = 3;
            };
        else
            Debug.LogError("Medium button not found in the UI document.");

        if (hardButton != null)
            hardButton.clicked += () => {
                Debug.Log("Hard button clicked!");
                SceneManager.LoadScene("Hard");
                GameManager.Instance.DifficultyScale = 10;
            };
        else
            Debug.LogError("Hard button not found in the UI document.");
    }

    // Responsible for switching between different menus by showing one and hiding the other.
    private void SwitchMenu(VisualElement menuToShow, VisualElement menuToHide){
        // Set the display style of the menuToShow to visible and the menuToHide to hidden.
        Debug.Log("Switching menu...");
        menuToHide.style.display = DisplayStyle.None;
        menuToShow.style.display = DisplayStyle.Flex;
    }
}
