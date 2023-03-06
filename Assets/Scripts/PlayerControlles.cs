using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlles : MonoBehaviour
{
    float xThrow;
    float yThrow;

    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based on player input")] [SerializeField] float movementSpeed = 0.1f;
    [Tooltip("How far the ship can move left or right on the screen")] 
    [SerializeField] float xRange = 5f;
    [Tooltip("How far the ship can move up and down on the screen")] 
    [SerializeField] float yRange = 5f;

    [Header("Laser Gun Array")]
    [Tooltip("An array of Laser GameObjects")] 
    [SerializeField] GameObject[] lasers;

    [Header("Pitch, Yaw and Roll Setup Settings")]
    [Tooltip("Up and down turning of the plane's nose")] 
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("")] 
    [SerializeField] float controlPitchFactor = -10f;
    [Tooltip("Left and right turning of the plane")] 
    [SerializeField] float positionYawFactor = 2f;
    [Tooltip("Clockwise and counter-clockwise turning of the plane")] 
    [SerializeField] float controlRollFactor = -20f;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * movementSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * movementSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z
        );
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y + positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition * pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
