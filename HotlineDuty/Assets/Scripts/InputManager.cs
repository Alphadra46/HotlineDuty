using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public PlayerInputAction playerinputActions;

    [Header("UI")]
    [HideInInspector] public InputAction navigate;
    [HideInInspector] public InputAction submit;
    [HideInInspector] public InputAction cancel;
    [HideInInspector] public InputAction point;
    [HideInInspector] public InputAction click;
    [HideInInspector] public InputAction scrollWheel;
    [HideInInspector] public InputAction middleClick;
    [HideInInspector] public InputAction rightClick;
    [HideInInspector] public InputAction trackedDevicePosition;
    [HideInInspector] public InputAction trackedDeviceOrientation;


    [Header("Game")] 
    [HideInInspector] public InputAction move;

    void Awake()
    {
        instance = this;
        playerinputActions = new PlayerInputAction();
        
        //InitUIInputs();
        //OnEnableUIInputs();
        
        InitInGameInputs();
        OnEnableInGameInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Init all fo the Inputs int the UI map from the custom PlayerInputActions
    /// </summary>
    /*
    public void InitUIInputs()
    {
        navigate = playerinputActions.UI.Navigate;
        submit = playerinputActions.UI.Submit;
        cancel = playerinputActions.UI.Cancel;
        point = playerinputActions.UI.Point;
        click = playerinputActions.UI.Click;
        scrollWheel = playerinputActions.UI.ScrollWheel;
        middleClick = playerinputActions.UI.MiddleClick;
        rightClick = playerinputActions.UI.RightClick;
        trackedDevicePosition = playerinputActions.UI.TrackedDevicePosition;
        trackedDeviceOrientation = playerinputActions.UI.TrackedDevicePosition;
    }
    */
    /// <summary>
    /// Used to enable all of the Inputs in the UI map from the custom PlayerInputActions
    /// </summary>
    public void OnEnableUIInputs()
    {
        navigate.Enable();
        submit.Enable();
        cancel.Enable();
        point.Enable();
        click.Enable();
        scrollWheel.Enable();
        middleClick.Enable();
        rightClick.Enable();
        trackedDevicePosition.Enable();
        trackedDeviceOrientation.Enable();
    }
    
    /// <summary>
    /// Used to disable all of the Inputs in the UI map from the custom PlayerInputActions
    /// </summary>
    public void OnDisableUIInputs()
    {
        navigate.Disable();
        submit.Disable();
        cancel.Disable();
        point.Disable();
        click.Disable();
        scrollWheel.Disable();
        middleClick.Disable();
        rightClick.Disable();
        trackedDevicePosition.Disable();
        trackedDeviceOrientation.Disable();
    }
    
    /// <summary>
    /// Init all fo the Inputs int the InGame map from the custom PlayerInputActions
    /// </summary>
    public void InitInGameInputs()
    {
        move = playerinputActions.Player.Movement;
    }
    
    /// <summary>
    /// Used to enable all of the Inputs in the InGame map from the custom PlayerInputActions
    /// </summary>
    public void OnEnableInGameInputs()
    {
        move.Enable();
    }
    
    /// <summary>
    /// Used to disable all of the Inputs in the InGame map from the custom PlayerInputActions
    /// </summary>
    public void OnDisableInGameInputs()
    {
        move.Disable();
    }
}
