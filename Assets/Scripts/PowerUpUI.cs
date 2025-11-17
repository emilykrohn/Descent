using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

// Requirement #17
public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private static Texture2D healthPowerUpImage;
    [SerializeField] private static Texture2D speedPowerUpImage;
    [SerializeField] private static Texture2D attackPowerUpImage;

    UIDocument uiDoc;
    bool isUiOpen = false;

    private Button buttonOne;
    private Button buttonTwo;
    private Button buttonThree;

    private Health health;
    [SerializeField] private int healthAmount = 10;

    private PlayerMovement playerMovement;
    [SerializeField] private float speedAmount = 2f;

    private AttackArea attackArea;
    [SerializeField] private int attackDamageAmount = 1;

    void Start()
    {
        health = FindFirstObjectByType<Health>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        attackArea = FindFirstObjectByType<AttackArea>();
    }

    void OnEnable()
    {
        Dictionary<string, Texture2D> powerUpDictionary = new Dictionary<string, Texture2D>
        {
            {"Health", healthPowerUpImage },
            {"Speed", speedPowerUpImage },
            {"Attack", attackPowerUpImage }
        };

        // Get the Power Up UI and hide it when the game is first run
        uiDoc = GetComponent<UIDocument>();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;

        // Find the Buttons from the UIDocument
        buttonOne = uiDoc.rootVisualElement.Q("PowerUpOneButton") as Button;
        buttonTwo = uiDoc.rootVisualElement.Q("PowerUpTwoButton") as Button;
        buttonThree = uiDoc.rootVisualElement.Q("PowerUpThreeButton") as Button;

        List<Button> buttons = new List<Button> { buttonOne, buttonTwo, buttonThree };
        
        // Loop through the buttons and assign them a random power-up from the dictionary
        for (int i = 0; i < buttons.Count; i++)
        {
            int randomIndex = Random.Range(0, powerUpDictionary.Count);
            string powerUpName = powerUpDictionary.ElementAt(randomIndex).Key;
            buttons[i].text = powerUpName;
            powerUpDictionary.Remove(powerUpName);
        }

        // When the buttons are pressed, it calls the ButtonPressed function
        buttonOne.RegisterCallback<ClickEvent>(HealthPowerUp);
        buttonTwo.RegisterCallback<ClickEvent>(SpeedPowerUp);
        buttonThree.RegisterCallback<ClickEvent>(AttackPowerUp);
    }

    void OnDisable()
    {
        buttonOne.UnregisterCallback<ClickEvent>(HealthPowerUp);
        buttonTwo.UnregisterCallback<ClickEvent>(SpeedPowerUp);
        buttonThree.UnregisterCallback<ClickEvent>(AttackPowerUp);
    }

    private void HealthPowerUp(ClickEvent evt)
    {
        Debug.Log("Heal PowerUp");
        health.Heal(healthAmount);

        HideUI();
    }

    private void SpeedPowerUp(ClickEvent evt)
    {
        Debug.Log("Speed PowerUp");
        playerMovement.SetSpeed(playerMovement.GetSpeed() + speedAmount);
        Debug.Log("New Speed: " + playerMovement.GetSpeed());

        HideUI();
    }

    private void AttackPowerUp(ClickEvent evt)
    {
        Debug.Log("Attack PowerUp");
        attackArea.SetDamage(attackArea.GetDamage() + attackDamageAmount);
        Debug.Log("New Attack Damage: " + attackArea.GetDamage());

        HideUI();
    }

    private void ButtonPressed(ClickEvent evt)
    {
        Debug.Log("Button Pressed");

        HideUI();
    }

    private void HideUI()
    {
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
