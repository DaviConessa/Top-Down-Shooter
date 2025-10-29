using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerControler : MonoBehaviour
{
    private PlayerInput _inputs;
    private InputAction _action;

    void Awake()
    {
        _inputs = GetComponent<PlayerInput>();
        _action = _inputs.actions["Move"];
        _action.ReadValue<Vector2>();
    }

    void OnMove(InputValue value)
    {
        Vector2 inputMove = _action.ReadValue<Vector2>();
    }
}