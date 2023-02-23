using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlles : MonoBehaviour
{
    // [SerializeField] InputAction movement;
    [SerializeField] float movementSpeed = 0.1f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        // float xThrow = movement.ReadValue<Vector2>().x;
        // float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * movementSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * movementSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (
            clampedXPos, 
            clampedYPos, 
            transform.localPosition.z
        );

    }

    // void onEnable()
    // {
    //     movement.Enable();
    // }

    // void onDisable()
    // {
    //     movement.Disable();
    // }
}
