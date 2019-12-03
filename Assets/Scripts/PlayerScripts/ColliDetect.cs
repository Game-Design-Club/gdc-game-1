using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliDetect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<PlayerMovement>().EnableJump();
            // Allows player to jump when touching the ground
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<PlayerMovement>().DisableJump();
            // Disables jump when player is not touching the ground.
        }
    }
}
