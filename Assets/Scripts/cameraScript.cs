using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    //get access to the player
    private GameObject player;
    private Vector3 MouseTracker;
    private float MouseX;
    private float MouseY;
    private Quaternion finalRotation;
    private float mouseSensitivity = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("playerLogic");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseTracker = Mouse.current.position.ReadValue();
        MouseX = (MouseTracker.x) * mouseSensitivity;
        MouseY = -1*(MouseTracker.y) * mouseSensitivity;
        MouseY = Mathf.Clamp(MouseY, -15, 35);
        //will only move if 
        finalRotation = Quaternion.Euler(MouseY, MouseX, 0);
        transform.position = player.transform.position - new Vector3(0f, 0f, 5.0f);
        transform.position = finalRotation * new Vector3(transform.position.x, player.transform.position.y + 2.0f, transform.position.z);
        transform.rotation = finalRotation;
        //Want to move camera base of mouse position
    }
}
