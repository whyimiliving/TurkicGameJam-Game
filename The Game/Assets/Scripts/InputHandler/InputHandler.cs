using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private InputData _inputData;
    private Vector2 moveInput;

    // Delegate alanları
    private Action<InputAction.CallbackContext> onMovementPerformed;
    private Action<InputAction.CallbackContext> onMovementCanceled;
    

    private void Awake()
    {
        _playerController = new PlayerController();
    }

    private void OnEnable()
    {
        _playerController.Enable();
        SubscribeEvents();
    }

    private void OnDisable()
    {
        _playerController.Disable();
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
      
        onMovementPerformed = HandleMovementPerformed;
        _playerController.Player.Movement.performed += onMovementPerformed;

        onMovementCanceled = HandleMovementCanceled;
        _playerController.Player.Movement.canceled += onMovementCanceled;
        
    }

    private void UnsubscribeEvents()
    {
   
        _playerController.Player.Movement.performed -= onMovementPerformed;
        _playerController.Player.Movement.canceled -= onMovementCanceled;
        
    }

    // Movement
    private void HandleMovementPerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        _inputData.InputVectorX = moveInput.x;
        _inputData.InputVectorY = moveInput.y;
    }

    private void HandleMovementCanceled(InputAction.CallbackContext ctx)
    {
        _inputData.InputVectorX = 0;
        _inputData.InputVectorY = 0;
    }
    
   
}
