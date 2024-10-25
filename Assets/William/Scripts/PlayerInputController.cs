using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    void OnEnable()
    {
        PlayerInput playerI = new PlayerInput();
        if (playerI != null)
        {
            playerI.InGame.Movement.performed += (val) => PlayerController.Instance.OnMove(val.ReadValue<Vector2>());

        }
        playerI.Enable();
    }
}