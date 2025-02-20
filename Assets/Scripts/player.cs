using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController playerCharacterController;
    private Vector3 playerVelocity;
    private float playerSpeed = 1.5f;
    private float gravity = -9.8f;
    private Vector3 inputs;
    private Animator playerAnimatorController;
    private bool isGrounded;
    private float JumpHeight;
    private bool isInAir;
    private void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
        if (!playerCharacterController)
        {
            Debug.Log("Unable to get reference to player character controller");
        }
        playerVelocity = Vector3.zero;
        inputs = Vector3.zero;

        playerAnimatorController = GetComponentInChildren<Animator>();
        JumpHeight = 10.0f;

    }

    private void Update()
    {
        isGrounded = playerCharacterController.isGrounded;
   
    }

    public void processMove(Vector2 input)
    {
        inputs.x = input.x;
        inputs.z = input.y;
        playerVelocity.y += gravity * Time.deltaTime;

        float rotationSpeed = 8.0f;
        //if (inputs.magnitude > 0.0f)
        if(inputs.x > 0.0f || inputs.z > 0.0f || inputs.x <0.0f || inputs.z < 0.0f) 
        {
            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(inputs);

            // Smoothly rotate towards target using Lerp (or Slerp for more natural motion)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        if (inputs.x == 1 || inputs.x == -1 || inputs.z == 1 || inputs.z == -1)
        {
            if (!isInAir)
            {
                playerAnimatorController.SetBool("isRunning", true);
            }
        }
        else
        {
            playerAnimatorController.SetBool("isRunning", false);
        }
        if(inputs.x != 0 && input.y != 0)
        {
            Debug.Log("Not move at same time");
        }
        else
        {
            playerCharacterController.Move(inputs * playerSpeed * Time.deltaTime);
            Debug.Log(inputs);
        }


        playerVelocity.y += gravity*Time.deltaTime;
        if(playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        playerCharacterController.Move(playerVelocity*Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log("Is Jumpung");
        if (isGrounded)
        {
            isInAir = false;
            //playerAnimatorController.SetBool("isWalking", false);
            playerVelocity.y = Mathf.Sqrt(Mathf.Pow(JumpHeight,2)*(-3.0f*gravity)*Time.deltaTime);

        }
        else
        {
            isInAir = true;
        }
        Debug.Log(playerVelocity);
    }

}
