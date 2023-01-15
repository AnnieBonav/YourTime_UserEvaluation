using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerTest : MonoBehaviour
{
    public UserEvaluation playerControllerTest;
    private InputAction select;

    // Start is called before the first frame update
    private void Awake()
    {
        playerControllerTest = new UserEvaluation();
    }

    private void OnEnable()
    {
        //select = playerControllerTest.UI.Click;
        playerControllerTest.Enable();
        playerControllerTest.Player.Fire.performed += Jump;
        playerControllerTest.Player.Move.performed += Move;
    }

    private void OnDisable()
    {
        playerControllerTest.Disable();
        playerControllerTest.Player.Fire.performed -= Jump;
        playerControllerTest.Player.Move.performed -= Move;
    }


    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumped inside callback");
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 move = playerControllerTest.Player.Move.ReadValue<Vector2>();
        Debug.Log(move);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerTest.Player.Fire.triggered)
        {
            Debug.Log("Jumped");
        }
    }
}
