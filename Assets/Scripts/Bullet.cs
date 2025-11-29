using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] float cooldown = 2f;
    [SerializeField] int damage = 3;
    
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
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
