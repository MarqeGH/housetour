using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    HitPointManager pHitPoints;
    GameObject player;
    int damageHitPoints;
    
    bool vulnerable = true;


    void Start()
    {
        player = GameObject.Find("Player");
        pHitPoints = player.GetComponent<HitPointManager>();
        damageHitPoints = pHitPoints.playerHitPoints;
    }

    void OnTriggerEnter(Collider other)
    {
        if (vulnerable) {
                damageHitPoints -= 1;
                vulnerable = !vulnerable;
                Invoke ("SetVulnerable", 1.5f);
        }
        Debug.Log("You have " + damageHitPoints + " hp left.");
    }

    void SetVulnerable()
    {
        vulnerable = !vulnerable;

    }
}
