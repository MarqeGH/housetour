using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] float clampX = 16f;
    [SerializeField] float clampY = 12f;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationFactor = 2f;
    [SerializeField] float controlRotationFactor = 30f;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;
        // xyThrow = new Vector3(xThrow, yThrow, 0);
    }

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
        xRestraint = Mathf.Clamp(xRestraint, -clampX, clampX);
        yRestraint = Mathf.Clamp(yRestraint, -clampY, clampY);
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
        
        float yawByTransform = transform.localPosition.x * rotationFactor;
        float yawByControl = xThrow*-controlRotationFactor;


        pitch = pitchByTransform + pitchByControl;
        roll = rollByTransform + rollByControl;
        yaw = yawByTransform + yawByControl;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
