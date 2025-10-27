using UnityEngine;
using UnityEngine.UIElements;

// Requirement #17
public class PowerUpUI : MonoBehaviour
{
    UIDocument uiDoc;
    bool isUiOpen = false;
    void Start()
    {
        // Get the Power Up UI and hide it when the game is first run
        uiDoc = GetComponent<UIDocument>();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;
    }

    void Update()
    {
        // When the user presses the Q button, the Power Up UI will be hidden if it was open and vice versa
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isUiOpen)
            {
                uiDoc.rootVisualElement.style.display = DisplayStyle.Flex;
                isUiOpen = true;
            }
            else
            {
                uiDoc.rootVisualElement.style.display = DisplayStyle.None;
                isUiOpen = false;
            }
        }
    }
}
