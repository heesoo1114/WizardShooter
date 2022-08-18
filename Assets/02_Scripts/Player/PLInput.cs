using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLInput : MonoBehaviour
{
    public UnityEvent<Vector2> MovementKeyPress;
    public UnityEvent<Vector2> PointerPositionChange;

    public UnityEvent ShootingButtonPress;
    public UnityEvent ShootingButtonRealease;
    public UnityEvent ChargingButtonPress;
    public UnityEvent ChargingButtonRealease;
    public UnityEvent ReloadButtonPress;

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetShootingInput();
        GetReloadInput();
        GetChargingInput();
    }

    private void GetChargingInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ChargingButtonPress?.Invoke();
        }
        else
        {
            ChargingButtonRealease?.Invoke();
        }
    }

    private void GetReloadInput()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadButtonPress?.Invoke();
        }
    }

    private void GetShootingInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootingButtonPress?.Invoke();
        }
        else
        {
            ShootingButtonRealease?.Invoke();
        }
    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector2 mouseInWordPos = Camera.main.ScreenToWorldPoint(mousePos);
        PointerPositionChange?.Invoke(mouseInWordPos);
    }

    private void GetMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        MovementKeyPress?.Invoke(new Vector2(x, y));
    }
}
