using UnityEngine;

public class TriShotAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(direction, transform, bulletSpeed);
        }
    }

    public void Shoot(Vector3 shootDirection, Transform shootOrigin, float bulletSpeed)
    {
        GameObject newBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootDirection.normalized * bulletSpeed;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Shoot second bullet with slight angle offset
        float offsetAngle = 15f; // degrees

        GameObject secondBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        Rigidbody2D rb2 = secondBullet.GetComponent<Rigidbody2D>();
        float angle2 = (angle + offsetAngle) * Mathf.Deg2Rad;
        Vector3 offsetDirection1 = new Vector3(Mathf.Cos(angle2), Mathf.Sin(angle2), 0);
        rb2.linearVelocity = offsetDirection1.normalized * bulletSpeed;
        secondBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offsetAngle));

        // Shoot third bullet with slight angle offset
        GameObject thirdBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        Rigidbody2D rb3 = thirdBullet.GetComponent<Rigidbody2D>();
        float angle3 = (angle - offsetAngle) * Mathf.Deg2Rad;
        Vector3 offsetDirection2 = new Vector3(Mathf.Cos(angle3), Mathf.Sin(angle3), 0);
        rb3.linearVelocity = offsetDirection2.normalized * bulletSpeed;
        thirdBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - offsetAngle));
    }
}
