using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 2f;
    
    public void DamageReceived(float damage) 
    {
        health -= damage;
        if(health <= 0f) {
            Die();
        }
    }
    void Die() {
        Destroy(gameObject);
    }
}
