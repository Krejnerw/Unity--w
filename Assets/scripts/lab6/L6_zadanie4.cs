using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_zadanie4 : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private GameObject player;
    private CharacterController controller;
    private bool groundedPlayer;
    private int changeState;

    void Start()
    {
        changeState = 0;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y > 9)
        // if (playerVelocity.y > 9)
        {
            changeState = 0;
            playerVelocity.y = 1f;
        }

        if (changeState == 1)
        {
            if (!groundedPlayer)
            {
                // playerVelocity.y = 3f;
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                // playerVelocity.y = 2;
            }
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("Player"))
        // {
        //     Debug.Log("Now juuump");
        //     other.gameObject.transform.position.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //     // playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }
        if (other.gameObject.CompareTag("Player"))
        {
            // groundedPlayer = false;
            changeState = 1;
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     // if (other.gameObject.CompareTag("Player"))
    //     // {
    //     //     Debug.Log("Now juuump");
    //     //     other.gameObject.transform.position.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //     //     // playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //     // }
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         // groundedPlayer = false;
    //         changeState = 1;
    //         // playerVelocity.y = 1f;
    //         // controller.Move(playerVelocity * Time.deltaTime);
    //     }
    // }
}
