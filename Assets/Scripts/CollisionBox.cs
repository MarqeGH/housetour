using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    HitPointManager pHitPoints;
    GameObject player;
    
    bool vulnerable = true;


    void Start()
    {
        player = GameObject.Find("Player");
        pHitPoints = player.GetComponent<HitPointManager>();
    }

    void OnTriggerEnter(Collider player)
    {
        if (vulnerable) {
                pHitPoints.playerHitPoints -= 1;
                vulnerable = !vulnerable;
                Invoke ("SetVulnerable", 1.5f);
        }
    }

    void SetVulnerable()
    {
        vulnerable = !vulnerable;
    }
}
