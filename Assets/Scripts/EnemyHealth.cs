using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] float startEnemyHealth = 100f;
    float currentEnemyHealth;
    GameObject enemyObject;
    float sourceDamage;
    void Start()
    {
        enemyObject = transform.parent.gameObject;
        currentEnemyHealth = startEnemyHealth;
    }

    void Update()
    {
        if (currentEnemyHealth <= 0)
        {
            Debug.Log("Enemy is dead");
            Invoke ("KillEnemy", 1);
        }
    }

    void OnParticleCollision(GameObject other) {
        sourceDamage = other.GetComponent<LaserDamage>().laserDMG;
        currentEnemyHealth -= sourceDamage;
        Debug.Log(currentEnemyHealth);
    }

    void KillEnemy()
    {
        Destroy(enemyObject);
    }
}
