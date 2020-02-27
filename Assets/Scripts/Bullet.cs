using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float velocity = 0.2f;
    private float angle;
    private bool calculateAngle = false;

    void Start()
    {
        
    }

    public void FixedUpdate()
    {
        move();
    }

    public void move()
    {

        if (!calculateAngle)
        {
            angle = this.transform.rotation.eulerAngles.z;
            if (angle > 180)
            {
                angle = angle - 360f;
            }

            angle *= Mathf.Deg2Rad;

            calculateAngle = true;
        }
        float x = Mathf.Cos(angle) * velocity;
        float y = Mathf.Sin(angle) * velocity;
        this.transform.position += new Vector3(-x, -y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
