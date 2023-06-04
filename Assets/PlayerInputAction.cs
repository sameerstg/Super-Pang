using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputAction : MonoBehaviour
{
    public PlayerInput inputAction;
    public Player player;
    private bool isFiring;

    void Awake()
    {
        player = GetComponent<Player>();
        inputAction = new();
        inputAction.Enable();
    }
    private void OnEnable()
    {
        inputAction.PlayerAction.Fire.started += Fire;
        inputAction.PlayerAction.Fire.canceled += FireStop;
    }

    private void FireStop(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isFiring = false;
    }

    private void Fire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isFiring = true;
        player.Move(Vector2.zero);
        player.Fire();
    }
    private void Update()
    {
        if (isFiring) return;


        if (inputAction.PlayerAction.Left.IsPressed()) player.Move(Vector2.left);
        else if (inputAction.PlayerAction.Right.IsPressed()) player.Move(Vector2.right);
        else if (player.rb.velocity != Vector2.zero)
        {
            player.Move(Vector2.zero);
        }
    }
    private void OnDisable()
    {
        inputAction.Disable();

    }
}
