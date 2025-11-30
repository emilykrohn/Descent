using UnityEngine;

public class XP : MonoBehaviour
{
    int xp = 10;
    XpBar xpBar;

    void Start()
    {
        xpBar = FindFirstObjectByType<XpBar>();
    }

    public void SetXP(int newXP)
    {
        xp = newXP;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player triggers the xp, increase their xp and update the xp bar
        if (collision.gameObject.tag == "Player")
        {
            // Increase the player's xp
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            playerStats.SetXP(playerStats.GetXP() + xp);
            xpBar.UpdateXp(xp);
            Destroy(gameObject);
        }
    }
}
