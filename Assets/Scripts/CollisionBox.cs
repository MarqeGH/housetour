using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    HitPointManager pHitPoints;
    GameObject player;
    int playerHitPoints;


    void Start()
    {
        player = GameObject.Find("Player");
        pHitPoints = player.GetComponent<HitPointManager>();
        playerHitPoints = pHitPoints.playerHitPoints;
    }

    void OnCollisionEnter(Collision player)
    {
        pHitPoints.playerHitPoints -= 1;
        Debug.Log("You have " + playerHitPoints + " hp left.");
    }
}
