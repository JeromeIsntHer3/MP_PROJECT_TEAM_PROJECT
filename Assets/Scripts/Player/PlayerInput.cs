using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movementInput;
    public bool jumpPressed { get; private set; }
    public bool jumpHeld { get; private set; }
    public bool jumpReleased { get; private set; }

    public KeyCode jumpKey;
    public KeyCode pauseKey;

    public static bool keysEnabled = true;

    void Awake()
    {
        keysEnabled = true;
    }

    void Update()
    {
        if (keysEnabled)
        {
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else
        {
            movementInput.x = 0;
        }

        if (!keysEnabled) return;
        jumpPressed = Input.GetKeyDown(jumpKey);
        jumpHeld = Input.GetKey(jumpKey);
        jumpReleased = Input.GetKeyUp(jumpKey);
    }
}