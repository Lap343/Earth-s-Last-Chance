using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlles : MonoBehaviour
{
    // [SerializeField] InputAction movement;
    [SerializeField] float movementSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        // float xThrow = movement.ReadValue<Vector2>().x;
        // float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * movementSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * movementSpeed;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3 (
            newXPos, 
            newYPos, 
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
