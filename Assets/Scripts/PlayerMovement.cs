using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour
{
    RectTransform moveCrosshair;
    float xRestraint;
    float yRestraint;
    Vector2 moveAmount;
    Vector2 crossPos;
    

    [SerializeField] float moveSpeed = 30f;


    void Start()
    {
        moveCrosshair = GetComponent<RectTransform>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
    }


    void Update()
    {
        CrossHairControl();
        xRestraint += moveAmount.x*moveSpeed;
        yRestraint += moveAmount.y*moveSpeed;
        moveCrosshair.localPosition = crossPos;
    }

    public void CrossHairControl()
    {
        xRestraint = Mathf.Clamp(xRestraint, -430f, 430f);
        yRestraint = Mathf.Clamp(yRestraint, -230f, 230f);
        crossPos = new Vector3(xRestraint, yRestraint, 200);
    }
}
