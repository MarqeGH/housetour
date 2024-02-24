using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] float moveSpeed;
    float xRestraint;
    float yRestraint;
    Vector3 shipPos;
    float xThrow;
    float yThrow;

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
        ShipControl();
        IncrementPosition();
    }
    void OnDisable(){
        movement.Disable();
    }



    public void ShipControl()
    {
        // float interpolationRatio = (float) elapsedFrames / interpolationFramesCount;
        xRestraint = Mathf.Clamp(xRestraint, -16f, 16f);
        yRestraint = Mathf.Clamp(yRestraint, -12f, 12f);
        shipPos = new Vector3(xRestraint, yRestraint, 0f);
        // shipPos = Vector3.Lerp(xyThrow.up, xyThrow.x, interpolationRatio);
    }
    public void IncrementPosition()
    {
        xRestraint += xThrow*moveSpeed*Time.deltaTime;
        yRestraint += yThrow*moveSpeed*Time.deltaTime;
        transform.localPosition = shipPos;
    }
}
