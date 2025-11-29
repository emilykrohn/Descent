using UnityEngine;

public class CannonPowerUp : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f;
    float timer = 0f;
    [SerializeField] float cooldown = 0.5f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        
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
        newBullet.transform.localScale *= 3;
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootDirection.normalized * bulletSpeed;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
