using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] float cooldown = 2f;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= cooldown)
        {
            Destroy(gameObject);
        }
    }
}
