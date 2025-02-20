using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputActionSetUp : MonoBehaviour
{
    //get access to our generated C# class
    private PlayerInputAction referenceToGeneratedClass;
    private PlayerInputAction.PlayerMovementActions referenceToGeneratedClassActionMap;
    private player Player;
    // Start is called before the first frame update
    private void Awake()
    {
        referenceToGeneratedClass = new PlayerInputAction();
        referenceToGeneratedClassActionMap = referenceToGeneratedClass.PlayerMovement;
        Player = GetComponent<player>();
        referenceToGeneratedClassActionMap.Jump.performed += ctx => Player.Jump();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Player.processMove(referenceToGeneratedClassActionMap.onFoot.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        referenceToGeneratedClassActionMap.Enable();
    }

    private void OnDisable()
    {
        referenceToGeneratedClassActionMap.Disable();
    }
}
