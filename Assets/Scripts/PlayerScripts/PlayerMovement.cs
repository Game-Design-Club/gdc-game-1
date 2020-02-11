using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 10f;
    [SerializeField] float sprintMultiplyer = 1f;
	[SerializeField] float jumpPower = 8f; 
	[SerializeField] float gravityScale = 1f;
	[SerializeField] float scaleDeducter = 0.1f;
	[SerializeField] float bufferMax = 0.25f;

    [SerializeField] Rigidbody2D rb;

	private PlayerPrefs playerPrefs = PlayerPrefs.GetInstance();

	private float bufferTimer = 100f;

	private bool isJumping;
	private bool isGrounded;
    private bool isSprinting;

	private void Start()
	{
		rb.gravityScale = gravityScale;
	}

    private void Update()
    {
        BufferJump();
    }

    private void FixedUpdate()
    {
		MovePlayer();
		ProcessOtherInputs();
		Jump();
    }

    private void ProcessOtherInputs() 
    {
        if (Input.GetKeyDown(playerPrefs.Sprint) && !isSprinting )
        {
            // Allows player to sprint if not already sprinting
            sprintMultiplyer = (float)(sprintMultiplyer * 1.5);
            // Changes the sprint multiplyer from 1 to 1.5, allowing the player to move 50% faster.
            isSprinting = true;
        }

        if (Input.GetKeyUp(playerPrefs.Sprint))
        {
            sprintMultiplyer = 1f;
            isSprinting = false;
            //todo check that sprint still works, if not delete isSprinting = false;
        }
    }

	private void MovePlayer()
	{
		if (Input.GetKey(playerPrefs.Move_Forward))
		{
			transform.Translate(Vector3.right * sprintMultiplyer * Time.deltaTime * horizontalSpeed);
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}
		else if(Input.GetKey(playerPrefs.Move_Backward))
		{
			transform.Translate(Vector3.left * sprintMultiplyer * Time.deltaTime * horizontalSpeed);
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}

		// ** Depreceated movement. Does not work with key binds. **
		//Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * sprintMultiplyer * Time.deltaTime * horizontalSpeed;
        // The two line above actually move the player.

    }

	// TODO Fix jumping so player can jump on anything (not just ground).
	private void Jump()
	{
		if (!Input.GetKey(playerPrefs.Jump)) 
		{
			isJumping = false;
		}

		if((Input.GetKeyDown(playerPrefs.Jump) || bufferTimer <= bufferMax) && isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpPower);
			isJumping = true;
			rb.gravityScale = scaleDeducter;
		}
		else if(isJumping && rb.gravityScale < gravityScale)
		{
			if(rb.velocity.y <= 0)
			{
				rb.gravityScale = gravityScale;
			} 
			else
			{
				rb.gravityScale += Time.deltaTime;
			}
		} 
		else
		{
			rb.gravityScale = gravityScale;
		}
	}

	private void BufferJump()
	{
		if(Input.GetKeyDown(playerPrefs.Jump))
		{
			bufferTimer = 0f;
		}

		if(bufferTimer <= bufferMax)
		{
			bufferTimer += Time.deltaTime;
		}
		else
		{
			bufferTimer = 100f;
		}
	}

	public void EnableJump()
	{
		isGrounded = true;
	}

	public void DisableJump()
	{
		isGrounded = false;
	}
}

	

