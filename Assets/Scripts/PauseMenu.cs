using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    UIDocument uiDoc;
    void OnEnable()
    {
        // Get the Power Up UI and hide it when the game is first run
        uiDoc = GetComponent<UIDocument>();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;
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