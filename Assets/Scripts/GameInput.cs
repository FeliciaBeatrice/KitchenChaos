using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {

    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        // enabling input actions means that Unity will start listening for and processing input from the specified action map (Player in this case)
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // listen on to whether Interact is performed and call Interact_performed
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // fire OnInteractAction event
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

}
