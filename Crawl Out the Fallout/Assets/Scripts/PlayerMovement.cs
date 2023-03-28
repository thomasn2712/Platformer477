using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Rigidbody2D rb = null;
    private Vector2 moveVector = Vector2.zero;
    [SerializeField]
    private float moveSpeed = 10;
    private void Awake() {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }
    private void OnDisable(){
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate(){
        rb.velocity = moveVector * moveSpeed * Time.deltaTime;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value){
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value){
        moveVector = Vector2.zero;
    }
}
