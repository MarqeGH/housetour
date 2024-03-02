using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class HitPointManager : MonoBehaviour
{
    
    [SerializeField] GameObject playerExplosion;
    [SerializeField] float timeToReset = 3f;
    [SerializeField] Transform parent;
    public int playerHitPoints = 5;
    Rigidbody rb;
    SplineAnimate splineAnimate;
    NewPlayerMovement newPlayerMovement;
    bool isDisabled = false;

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
        if (playerHitPoints <= 0 && isDisabled == false)
        {
            isDisabled = true;
            rb.drag = 0.5f;
            rb.useGravity = true;
            rb.isKinematic = false;
            newPlayerMovement.enabled = false;
            splineAnimate.enabled = false;
            Invoke ("ResetLevel", timeToReset);
            Instantiate(playerExplosion, new Vector3(transform.position.x-0.5f, transform.position.y+3f, transform.position.z-5f), Quaternion.identity);
        }
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
