using UnityEngine;

// Requirement #17
public class TriShotAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f;
    float timer = 0f;
    [SerializeField] float cooldown = 0.1f;

    void Update()
    {
        // Get the mouse position and find the direction it is from the player
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
    
        // Shoot a bullet when space bar is pressed and cooldown has passed
        if(Input.GetKeyDown(KeyCode.Space) && timer >= cooldown)
        {
            Shoot(direction, transform, bulletSpeed);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    public void Shoot(Vector3 shootDirection, Transform shootOrigin, float bulletSpeed)
    {
        GameObject newBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        // Use physics to move the bullet
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootDirection.normalized * bulletSpeed;
        // Find the angle where the bullet will move towards
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Shoot second bullet with slight angle offset
        float offsetAngle = 15f; // degrees

        GameObject secondBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        // Use physics to move the bullet
        Rigidbody2D rb2 = secondBullet.GetComponent<Rigidbody2D>();
        // Find the angle where the bullet will move towards and offset it
        float angle2 = (angle + offsetAngle) * Mathf.Deg2Rad;
        Vector3 offsetDirection1 = new Vector3(Mathf.Cos(angle2), Mathf.Sin(angle2), 0);
        rb2.linearVelocity = offsetDirection1.normalized * bulletSpeed;
        secondBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offsetAngle));

        // Shoot third bullet with slight angle offset
        GameObject thirdBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        // Use physics to move the bullet
        Rigidbody2D rb3 = thirdBullet.GetComponent<Rigidbody2D>();
        // Find the angle where the bullet will move towards and offset it
        float angle3 = (angle - offsetAngle) * Mathf.Deg2Rad;
        Vector3 offsetDirection2 = new Vector3(Mathf.Cos(angle3), Mathf.Sin(angle3), 0);
        rb3.linearVelocity = offsetDirection2.normalized * bulletSpeed;
        thirdBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - offsetAngle));
    }
}
