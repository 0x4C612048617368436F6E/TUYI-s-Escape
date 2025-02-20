using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    //get access to the player
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("playerLogic");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - new Vector3(0f, 0f, 5.0f);
        transform.position = new Vector3(transform.position.x, player.transform.position.y+2.0f, transform.position.z);
    }
}
