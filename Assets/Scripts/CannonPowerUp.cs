using UnityEngine;

// Requirement #7
public class CannonPowerUp : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f;
    float timer = 0f;
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] int attackDamage = 5;

    void Update()
    {
        if (Camera.main != null)
        {
            // Get the mouse position and find the direction it is from the player
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            
            // Shoot if the space bar is pressed and cooldown has passed
            if(Input.GetKeyDown(KeyCode.Space) && timer >= cooldown)
            {
                if (bullet != null)
                {
                    Shoot(direction, transform, bulletSpeed);
                    timer = 0f;
                }
            }
            timer += Time.deltaTime;
        }
    }

    public void Shoot(Vector3 shootDirection, Transform shootOrigin, float bulletSpeed)
    {
        if (bullet != null)
        {
            // Use bullet prefab and make it larger for cannon power up
            GameObject newBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
            if (newBullet != null)
            {
                newBullet.transform.localScale *= 3;
                // Use physics to move the bullet
                Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = shootDirection.normalized * bulletSpeed;
                }
                // Find the angle where the bullet will move towards
                float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }
}
