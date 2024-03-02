using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] float startEnemyHealth = 100f;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] Transform parent;
    [SerializeField] float timeTillDestroy = 3f;
    [SerializeField] int pointValue = 1;
    GameObject vfx;
    float currentEnemyHealth;
    GameObject enemyObject;
    float sourceDamage;
    ScoreBoard scoreBoard;
    bool isDisabled;
    void Start()
    {
        enemyObject = transform.parent.gameObject;
        currentEnemyHealth = startEnemyHealth;
        scoreBoard = FindObjectOfType<ScoreBoard>();
        isDisabled = false;
    }

    void Update()
    {
        if (currentEnemyHealth <= 0 && isDisabled == false)
        {
            isDisabled = true;
            Debug.Log("Enemy is dead");
            scoreBoard.IncrementScore(pointValue);
            DeathVFX();
            KillEnemy();
        }
    }

    void OnParticleCollision(GameObject other) {
        sourceDamage = other.GetComponent<LaserDamage>().laserDMG;
        currentEnemyHealth -= sourceDamage;
        Debug.Log(currentEnemyHealth);
    }

    void DeathVFX()
    {
        vfx = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(vfx, timeTillDestroy);
    }

    void KillEnemy()
    {
        Destroy(enemyObject);
    }
}
