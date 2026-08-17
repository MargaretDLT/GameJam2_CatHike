using UnityEngine;
using UnityEngine.InputSystem;

// Copyright © 2026 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class FancyPlayer : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;

    public AudioClip JumpSFX;
    public int IndexSFX;

    private CharacterController playerController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        IndexSFX = SoundBoard.Instance.AddSoundEffect(JumpSFX);

        playerController = GetComponent<CharacterController>();
        playerVelocity = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // get input for player movement
        //Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		// Rotate around y-axis based on input, A & D keys
		float horizontal;
		if (Keyboard.current.aKey.isPressed)
		{
			horizontal = -1.0f;
		}
		else
		{
			if (Keyboard.current.dKey.isPressed)
			{
				horizontal = 1.0f;
			}
			else
			{
				horizontal = 0.0f;
			}
		}

		// set forward/backward movement based on input, W & S keys
		float vertical;
		if (Keyboard.current.wKey.isPressed)
		{
			vertical = 1.0f;
		}
		else
		{
			if (Keyboard.current.sKey.isPressed)
			{
				vertical = -1.0f;
			}
			else
			{
				vertical = 0.0f;
			}
		}
        Vector3 moveVector = new Vector3(horizontal, 0, vertical);

		// adjust player speed
		moveVector *= playerSpeed;

        // orient player based on input vectors
        if (moveVector != Vector3.zero)
        {
            gameObject.transform.forward = moveVector;
        }

        // detect if the player is on the ground and zero Y-axis
        groundedPlayer = playerController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // calculate the Y-axis based on jumping and gravity
        if (Keyboard.current.spaceKey.isPressed && groundedPlayer)
        {
            // play jump sound
            SoundBoard.Instance.PlaySFX(IndexSFX);

            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue); // instant impulse when jump pressed
        }
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        playerVelocity.y += gravityValue * Time.deltaTime;

        // adjust player movement in Y-axis
        moveVector.y = playerVelocity.y;

        // actually move the player
        playerController.Move(moveVector * Time.deltaTime);
    }
}