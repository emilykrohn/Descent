using UnityEngine;
using UnityEngine.UIElements;

// Requirement #17
public class PowerUpUI : MonoBehaviour
{
    UIDocument uiDoc;
    bool isUiOpen = false;

    private Button buttonOne;
    private Button buttonTwo;
    private Button buttonThree;

    void OnEnable()
    {
        // Get the Power Up UI and hide it when the game is first run
        uiDoc = GetComponent<UIDocument>();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;

        // Find the Buttons from the UIDocument
        buttonOne = uiDoc.rootVisualElement.Q("PowerUpOneButton") as Button;
        buttonTwo = uiDoc.rootVisualElement.Q("PowerUpTwoButton") as Button;
        buttonThree = uiDoc.rootVisualElement.Q("PowerUpThreeButton") as Button;

        // When the buttons are pressed, it calls the ButtonPressed function
        buttonOne.RegisterCallback<ClickEvent>(ButtonPressed);
        buttonTwo.RegisterCallback<ClickEvent>(ButtonPressed);
        buttonThree.RegisterCallback<ClickEvent>(ButtonPressed);
    }

    void OnDisable()
    {
        buttonOne.UnregisterCallback<ClickEvent>(ButtonPressed);
        buttonTwo.UnregisterCallback<ClickEvent>(ButtonPressed);
        buttonThree.UnregisterCallback<ClickEvent>(ButtonPressed);
    }

    private void ButtonPressed(ClickEvent evt)
    {
        Debug.Log("Button Pressed");

        // Hide UI after button is pressed
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;
        isUiOpen = false;
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
