using UnityEngine;

public class Hp : MonoBehaviour
{
       public int health = 5;
    // send message method
    void TakeDamage(int damage){
        health -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Remaining health: " + health);
        if(health <= 0){
            Die();
        }
    }
    void Die(){
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}