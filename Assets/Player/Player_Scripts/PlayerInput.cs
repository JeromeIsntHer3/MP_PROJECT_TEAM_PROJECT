using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movementInput;
    public bool jumpPressed { get; private set; }
    public bool jumpHeld { get; private set; }
    public bool jumpReleased { get; private set; }
    public bool swapPerspective { get; private set; }

    public KeyCode jumpKey;
    public KeyCode pauseKey;
    public KeyCode swapKey;

    public static bool keysEnabled = true;

    public static event Action GamePaused;

    void Awake()
    {
        keysEnabled = true;
    }

    void OnEnable()
    {
        GamePaused += DisableKeys;
    }

    void OnDisable()
    {
        GamePaused -= DisableKeys;
    }

    void Update()
    {
        if (!keysEnabled) return;
        movementInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        jumpPressed = Input.GetKeyDown(jumpKey);
        jumpHeld = Input.GetKey(jumpKey);
        jumpReleased = Input.GetKeyUp(jumpKey);

        if (Input.GetKeyDown(swapKey))
        {
            swapPerspective = !swapPerspective;
        }
        if (Input.GetKeyDown(pauseKey))
        {
            GamePaused?.Invoke();
        }
    }

    void DisableKeys()
    {
        keysEnabled = false;
    }
}