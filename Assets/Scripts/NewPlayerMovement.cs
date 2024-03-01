using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewPlayerMovement : MonoBehaviour
{


    [Header("Input Settings")]
    [Tooltip("Control input vertical and horizontal")][SerializeField] InputAction movement;
    [Tooltip("Control input shooting lasers")][SerializeField] InputAction fire;
    [Header("Laser gun array")]
    [Tooltip("Array holding Lasers")][SerializeField] GameObject[] lasers;
    public float laserDamage = 10f;

    [Header("Position and Rotation limits")]
    [Tooltip("How far up and down Ship can move")][SerializeField] float posClampX = 16f;
    [Tooltip("How far left and right Ship can move")][SerializeField] float posClampY = 12f;
    [Tooltip("How far up and down Ship can pitch")][SerializeField] float pitchMinMax = 45f;
    [Tooltip("How far left and right Ship can roll")][SerializeField] float rollMinMax = 90f;

    [Header("Movement Speeds")]
    [Tooltip("How fast ship moves")] [SerializeField] float moveSpeed;
    [Tooltip("How fast ship rotates by movement")][SerializeField] float rotationFactor = 2f;
    [Tooltip("How fast ship rotates by input")][SerializeField] float controlRotationFactor = 30f;



    float xRestraint;
    float yRestraint;
    Vector3 shipPos;
    float xThrow;
    float yThrow;
    float pitch;
    float yaw;
    float roll;


    // public int interpolationFramesCount = 45;
    // Vector3 xyThrow;
    // int elapsedFrames = 0;

    void OnEnable(){
        movement.Enable();
        fire.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        // laserLeft = laserLeft.GetComponent<ParticleSystem>();
        // laserRight = laserRight.GetComponent<ParticleSystem>();
        // Debug.Log(laserRight.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        ShootButtonHeld();
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;
    }
    void ShootButtonHeld()
    {
        if( fire.ReadValue<float>() > 0.5f )
        {
            ActivateLasers();
        }
        

    }

    void ActivateLasers()
    {
        foreach (GameObject laser in lasers) {
            laser.GetComponent<ParticleSystem>().Play();
        }
    }
    // void DeactivateLasers()
    // {
    //     foreach (GameObject laser in lasers) {
    //         laser.GetComponent<ParticleSystem>().Stop();
    //     }
    // }

    void FixedUpdate() {
        ShipTranslation();
        ShipRotation();
    }

    void OnDisable(){
        movement.Disable();
    }
    void ShipTranslation()
    {
        // float interpolationRatio = (float) elapsedFrames / interpolationFramesCount;
        xRestraint = Mathf.Clamp(xRestraint, -posClampX, posClampX);
        yRestraint = Mathf.Clamp(yRestraint, -posClampY, posClampY);

        shipPos = new Vector3(xRestraint, yRestraint, 0f);
        // shipPos = Vector3.Lerp(xyThrow.up, xyThrow.x, interpolationRatio);
        xRestraint += xThrow*moveSpeed*Time.deltaTime;
        yRestraint += yThrow*moveSpeed*Time.deltaTime;
        transform.localPosition = shipPos;
    }

    void ShipRotation()
    {

        float pitchByTransform = transform.localPosition.y * -rotationFactor/2;
        float pitchByControl = yThrow*controlRotationFactor*2;

        float rollByTransform = transform.localPosition.x * -rotationFactor;
        float rollByControl = xThrow*controlRotationFactor*2;
        
        float yawByTransform = transform.localPosition.x * rotationFactor/2;
        float yawByControl = xThrow*-controlRotationFactor/2;

        pitch = pitchByTransform + pitchByControl;
        roll = rollByTransform + rollByControl;
        yaw = yawByTransform + yawByControl;

        pitch = Mathf.Clamp(pitch, -pitchMinMax, pitchMinMax);
        roll = Mathf.Clamp(roll, -rollMinMax, rollMinMax);

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
