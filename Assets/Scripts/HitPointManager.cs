using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointManager : MonoBehaviour
{

    public int playerHitPoints = 5;
    public int fighterHitPoints = 3;

    void Start()
    {
        int currentHitPoints = playerHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHitPoints);
    }
}
