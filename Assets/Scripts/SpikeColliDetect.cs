using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeColliDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
