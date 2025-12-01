using UnityEngine;

//Requirement # 6
public class Bullet : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] float cooldown = 2f;
    int damage = 3;

    void Start()
    {
        PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
        if (playerStats != null)
        {
            damage = playerStats.GetAttack();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= cooldown)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Health health = collider.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage);
            }
            Destroy(gameObject);
        }
    }
}
