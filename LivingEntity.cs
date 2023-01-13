using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;
    protected virtual void Start() {
        health = startingHealth;
    }
    public void TakeHit(float damage, RaycastHit hit) {
        // track raycasthit later
        TakeDamage(damage);
    }

    public void TakeDamage(float damage) {
        health -= damage;
        // print(health);
        if( health <=0 && !dead ){
            Die();
        }
    }

    protected void Die() {
        // print("Sethu po thailee");
        dead = true;
        if(OnDeath != null) {
            OnDeath();
        }
        GameObject.Destroy(gameObject); 
    }
}
