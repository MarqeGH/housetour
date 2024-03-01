using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class HitPointManager : MonoBehaviour
{
    Rigidbody rb;
    SplineAnimate splineAnimate;
    NewPlayerMovement newPlayerMovement;
    public int playerHitPoints = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        splineAnimate = transform.parent.GameObject().GetComponent<SplineAnimate>();
        newPlayerMovement = GetComponent<NewPlayerMovement>();
        int currentHitPoints = playerHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHitPoints <= 0)
        {
            rb.drag = 0.5f;
            rb.useGravity = true;
            rb.isKinematic = false;
            newPlayerMovement.enabled = false;
            splineAnimate.enabled = false;
            Invoke ("ResetLevel", 3);
        }
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
