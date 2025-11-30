using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

// Requirement #17
public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private Texture2D healthPowerUpImage;
    [SerializeField] private Texture2D speedPowerUpImage;
    [SerializeField] private Texture2D attackPowerUpImage;
    [SerializeField] private Texture2D basicGunPowerUpImage;
    [SerializeField] private Texture2D triShotGunPowerUpImage;
    [SerializeField] private Texture2D cannonPowerUpImage;

    UIDocument uiDoc;
    bool isUiOpen = false;

    private Button buttonOne;
    private Button buttonTwo;
    private Button buttonThree;

    private VisualElement imageOne;
    private VisualElement imageTwo;
    private VisualElement imageThree;
    
    List<string> functionOrderList = new List<string>();
    List<Button> buttons;

    private Health health;
    [SerializeField] private int healthAmount = 10;

    private PlayerMovement playerMovement;
    [SerializeField] private float speedAmount = 2f;

    [SerializeField] private int attackDamageAmountIncrease = 1;
    private int totalAttackIncrease = 0;
    private BaseLongRangeAttack basicGunAttack;
    private PlayerAttack playerAttack;
    private TriShotAttack triShotAttack;
    private CannonPowerUp cannonPowerUp;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        health = FindFirstObjectByType<Health>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerAttack = FindFirstObjectByType<PlayerAttack>();
        basicGunAttack = FindFirstObjectByType<BaseLongRangeAttack>();
        triShotAttack = FindFirstObjectByType<TriShotAttack>();
        cannonPowerUp = FindFirstObjectByType<CannonPowerUp>();
    }

    void OnEnable()
    {
        // Get the Power Up UI and hide it when the game is first run
        uiDoc = GetComponent<UIDocument>();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;

        // Find the Buttons from the UIDocument
        buttonOne = uiDoc.rootVisualElement.Q("PowerUpOneButton") as Button;
        buttonTwo = uiDoc.rootVisualElement.Q("PowerUpTwoButton") as Button;
        buttonThree = uiDoc.rootVisualElement.Q("PowerUpThreeButton") as Button;

        // Find the Images from the UIDocument
        imageOne = uiDoc.rootVisualElement.Q("PowerUpImageOne");
        imageTwo = uiDoc.rootVisualElement.Q("PowerUpImageTwo");
        imageThree = uiDoc.rootVisualElement.Q("PowerUpImageThree");
    }

    private void LoadUI()
    {
        // dictionary of power ups and their images
        Dictionary<string, Texture2D> powerUpDictionary = new Dictionary<string, Texture2D>
        {
            {"Health", healthPowerUpImage },
            {"Speed", speedPowerUpImage },
            {"Attack", attackPowerUpImage },
            {"Basic Gun", basicGunPowerUpImage },
            {"Tri-Shot Gun", triShotGunPowerUpImage },
            {"Cannon", cannonPowerUpImage }
        };

        // Create lists for buttons and images that will be used for loops
        buttons = new List<Button> { buttonOne, buttonTwo, buttonThree };
        List<VisualElement> images = new List<VisualElement> { imageOne, imageTwo, imageThree };

        // Loop through the buttons and assign them a random power-up from the dictionary
        for (int i = 0; i < buttons.Count; i++)
        {
            int randomIndex = Random.Range(0, powerUpDictionary.Count);
            string powerUpName = powerUpDictionary.ElementAt(randomIndex).Key;
            buttons[i].text = powerUpName;
            if (powerUpName == "Health")
            {
                buttons[i].RegisterCallback<ClickEvent>(HealthPowerUp);
            }
            else if (powerUpName == "Speed")
            {
                buttons[i].RegisterCallback<ClickEvent>(SpeedPowerUp);
            }
            else if (powerUpName == "Attack")
            {
                buttons[i].RegisterCallback<ClickEvent>(AttackPowerUp);
            }
            else if (powerUpName == "Basic Gun")
            {
                buttons[i].RegisterCallback<ClickEvent>(BasicGunPowerUp);
            }
            else if (powerUpName == "Tri-Shot Gun")
            {
                buttons[i].RegisterCallback<ClickEvent>(TriShotGunPowerUp);
            }
            else if (powerUpName == "Cannon")
            {
                buttons[i].RegisterCallback<ClickEvent>(CannonPowerUp);
            }
            functionOrderList.Add(powerUpName);
            images[i].style.backgroundImage = new StyleBackground(powerUpDictionary[powerUpName]);
            powerUpDictionary.Remove(powerUpName);
        }
    }

    private void CannonPowerUp(ClickEvent evt)
    {
        cannonPowerUp.enabled = true;
        playerAttack.enabled = false;
        basicGunAttack.enabled = false;
        triShotAttack.enabled = false;

        playerStats.SetAttack(cannonPowerUp.GetAttackDamage() + totalAttackIncrease);

        HideUI();
    }

    private void BasicGunPowerUp(ClickEvent evt)
    {
        basicGunAttack.enabled = true;
        playerAttack.enabled = false;
        triShotAttack.enabled = false;
        cannonPowerUp.enabled = false;

        playerStats.SetAttack(basicGunAttack.GetAttackDamage() + totalAttackIncrease);

        HideUI();
    }

    private void TriShotGunPowerUp(ClickEvent evt)
    {
        basicGunAttack.enabled = false;
        playerAttack.enabled = false;
        triShotAttack.enabled = true;
        cannonPowerUp.enabled = false;

        playerStats.SetAttack(triShotAttack.GetAttackDamage() + totalAttackIncrease);

        HideUI();
    }

    private void HealthPowerUp(ClickEvent evt)
    {
        health.Heal(healthAmount);

        HideUI();
    }

    private void SpeedPowerUp(ClickEvent evt)
    {
        playerMovement.SetSpeed(playerMovement.GetSpeed() + speedAmount);

        HideUI();
    }

    private void AttackPowerUp(ClickEvent evt)
    {
        playerStats.SetAttack(playerStats.GetAttack() + attackDamageAmountIncrease);
        totalAttackIncrease += attackDamageAmountIncrease;
        
        HideUI();
    }

    private void HideUI()
    {
        // Hide UI after button is pressed
        UnregisterCallbacks();
        uiDoc.rootVisualElement.style.display = DisplayStyle.None;
        isUiOpen = false;
        Time.timeScale = 1f;
    }

    public void OpenUI()
    {
        if (!isUiOpen)
        {
            uiDoc.rootVisualElement.style.display = DisplayStyle.Flex;
            isUiOpen = true;
            Time.timeScale = 0f;
            LoadUI();
        }
    }

    private void UnregisterCallbacks()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].UnregisterCallback<ClickEvent>(HealthPowerUp);
            buttons[i].UnregisterCallback<ClickEvent>(SpeedPowerUp);
            buttons[i].UnregisterCallback<ClickEvent>(AttackPowerUp);
            buttons[i].UnregisterCallback<ClickEvent>(BasicGunPowerUp);
            buttons[i].UnregisterCallback<ClickEvent>(TriShotGunPowerUp);
            buttons[i].UnregisterCallback<ClickEvent>(CannonPowerUp);
        }
    }
}
