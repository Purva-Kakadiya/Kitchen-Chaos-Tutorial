using System;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    private InputSystem_Actions inputActions;

    private void Awake() {
        Instance = this;

        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();

        inputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        inputActions.Player.Interact.performed += Interact_performed;
        inputActions.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy() {
        inputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        inputActions.Player.Interact.performed -= Interact_performed;
        inputActions.Player.Pause.performed -= Pause_performed;

        inputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

}
