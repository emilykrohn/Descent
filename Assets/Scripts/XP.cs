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
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            playerStats.SetXP(playerStats.GetXP() + xp);
            xpBar.UpdateXp(playerStats.GetXP());
            Destroy(gameObject);
        }
    }
}
