using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 10f;
    [SerializeField] float sprintMultiplyer = 1f;
	[SerializeField] float jumpPower = 10f; 
	[SerializeField] float gravityScale = 1f;
	[SerializeField] float scaleDeducter = 0.1f;
	[SerializeField] float bufferMax = 0.25f;
	[SerializeField] float dodgeModifier = .3df; //keep this below 1f please
	[SerializeField] readonly float dodgeTimeTop = 2f;
	[SerializeField]  float dodgeTime = 0f;

	[SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D player;

	private float bufferTimer = 100f;

	public bool isJumping;
	private bool isGrounded;
    private bool isSprinting;
	[SerializeField] private bool canDodge = true;

	//private bool canDodge = true;

	private void Start()
	{
		rb.gravityScale = gravityScale;
	}

    private void Update()
    {
        bufferJump();
    }

    private void FixedUpdate()
    {
		MovePlayer();
		ProcessOtherInputs();
		Jump();
    }

	private void ProcessOtherInputs()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
		{
			// Allows player to sprint if not already sprinting
			sprintMultiplyer = (float)(sprintMultiplyer * 1.5);
			// Changes the sprint multiplyer from 1 to 1.5, allowing the player to move 50% faster.
			isSprinting = true;
		}

		if (Input.GetKeyDown(KeyCode.P) && canDodge)
		{
			Dodge();
		}

		//if (Input.GetKeyUp(KeyCode.P) || !canDodge)
		//{
		//	sprintMultiplyer = 1f;
		//	isDodging = false;
		//	//todo check that sprint still works, if not delete isSprinting = false;
		//}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			sprintMultiplyer = 1f;
			isSprinting = false;
			//todo check that sprint still works, if not delete isSprinting = false;
		}
	}

	private void MovePlayer()
	{
		// Records player horizontal movement factor, then moves the player
		// Should work for controller?
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
		transform.position += movement * sprintMultiplyer * Time.deltaTime * horizontalSpeed;
		// The two line above actually move the player.

		// Flips the character based on which way it moves.
		if (Input.GetAxis("Horizontal") < 0f)
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (Input.GetAxis("Horizontal") > 0f)
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}
	}

	private void Dodge()
	{
        float direction = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(direction, 0f, 0f);

        for (float i = 0; i <= 1f; i += Time.fixedDeltaTime)
        {
            transform.position += movement * dodgeModifier * Time.deltaTime * horizontalSpeed;
        }

        //dodgeCooldown(); Having trouble on the cooldown for Dodge, but the rest is good (2/17/2020)
	}

    private void dodgeCooldown()
    {
        dodgeTime = 0f;

		while (dodgeTime <= dodgeTimeTop)
        {
			dodgeTime += Time.deltaTime;

            canDodge = false;
        }

		canDodge = true;

		dodgeTime = 0f;
    }

	private void Jump()
	{
		if (!Input.GetKey(KeyCode.Space) || !Input.GetKey(KeyCode.W)) 
		{
			isJumping = false;
		}

		if((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W) || bufferTimer <= bufferMax) && isGrounded)
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

	private void bufferJump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
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

    public void KnockBackPlayer(float direction, float knockBackXForce, float knockBackYForce)
    {
        if (direction > 0)
        {
            print("Knockback ran");
            player.AddForce(Vector2.left * knockBackXForce);

            if (!isJumping)
            {
                player.AddForce(Vector2.up * knockBackYForce);
            }
        }

        else
        {
            player.AddForce(Vector2.right * knockBackXForce);

            if (!isJumping)
            {
                player.AddForce(Vector2.up * knockBackYForce);
            }
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







