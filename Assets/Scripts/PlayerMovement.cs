using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    RectTransform moveCrosshair;
    float xRestraint;
    float yRestraint;
    Vector2 moveAmount;
    Vector2 crossPos;

    KeyControl debug;
    

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
    public void OnShoot(InputAction.CallbackContext shoot)
    {
        if (shoot.started){Debug.Log("Shooting started");}
        else if (shoot.performed){Debug.Log("Shooting performed");}
        else if (shoot.canceled){Debug.Log("Shooting canceled");}
    }


    void Update()
    {
        CrossHairControl();
    }

    public void CrossHairControl()
    {
        IncrementPosition();
        xRestraint = Mathf.Clamp(xRestraint, -350f, 350f);
        yRestraint = Mathf.Clamp(yRestraint, -200f, 200f);
        crossPos = new Vector3(xRestraint, yRestraint, -200f);
    }
    public void IncrementPosition()
    {
        xRestraint += moveAmount.x*moveSpeed;
        yRestraint += moveAmount.y*moveSpeed;
        moveCrosshair.localPosition = crossPos;
    }
}
