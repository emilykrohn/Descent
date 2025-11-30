using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    UIDocument uiDoc;
    private Button buttonOne;
    private Button buttonTwo;
    private Button buttonThree;

    void OnEnable()
    {
        // Get the Power Up UI and hide it when the game is first run
        uiDoc = GetComponent<UIDocument>();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;

        // Find the Buttons from the UIDocument
        buttonOne = uiDoc.rootVisualElement.Q("ResumeButton") as Button;
        buttonTwo = uiDoc.rootVisualElement.Q("SaveButton") as Button;
        buttonThree = uiDoc.rootVisualElement.Q("MainMenuButton") as Button;

        buttonOne.RegisterCallback<ClickEvent>(ResumeGame);
        buttonTwo.RegisterCallback<ClickEvent>(SaveGame);
        buttonThree.RegisterCallback<ClickEvent>(ReturnToMainMenu);
    }

    private void ResumeGame(ClickEvent evt)
    {
        CloseUI();
    }

    private void SaveGame(ClickEvent evt)
    {
        Debug.Log("Game Saved!");
        CloseUI();
    }

    private void ReturnToMainMenu(ClickEvent evt)
    {
        Debug.Log("Returning to Main Menu!");
        CloseUI();
    }

    void Update()
    {
        // Escape key opens and closes the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiDoc.rootVisualElement.style.display == DisplayStyle.None)
            {
                OpenUI();
            }
            else
            {
                CloseUI();
            }
        }
    }

    private void OpenUI()
    {
        // Show the pause menu UI and pause the game
        uiDoc.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
    }

    private void CloseUI()
    {
        // Hide the pause menu UI and unpause the game
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
    }
}