using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnt : MonoBehaviour
{
    private GameObject bulletAnt;
    private GameObject bullet;

    private float attackTimer = 0f;
    int bullets = 0;
    private float attackCooldown = 0f;
    private bool attacking = false;
    private float velocity = -0.05f;
    private bool calculateAngle = false;
    private float angle = 0f;
    private bool firstEnter = true;
    private bool firstExit = false;
    private bool checkEnter = false;

    private Sprite[] sprites;

    void Start()
    {
        bulletAnt = GameObject.FindGameObjectWithTag("BulletAnt");

        sprites = Resources.LoadAll<Sprite>("Bullet Bill 1.1");

        BoxCollider2D colliderR = bulletAnt.AddComponent<BoxCollider2D>();
        colliderR.isTrigger = true;
        colliderR.size = new Vector2(0.5f, 2.25f);
        colliderR.offset = new Vector2(1.5f, 0.0f);
        BoxCollider2D colliderL = bulletAnt.AddComponent<BoxCollider2D>();
        colliderL.isTrigger = true;
        colliderL.size = new Vector2(0.5f, 2.25f);
        colliderL.offset = new Vector2(-1.5f, 0.0f);
    }

    public void FixedUpdate()
    {
        Attack();
    }

    private void Attack()
    {
        if (attackTimer > 15f && bullets < 3)
        {
            bullet = new GameObject("bullet");
            bullet.AddComponent<BoxCollider2D>();
            bullet.AddComponent<SpriteRenderer>();
            bullet.GetComponent<SpriteRenderer>().sprite = sprites[0];
            bullet.AddComponent<Bullet>();
            bullet.GetComponent<BoxCollider2D>().autoTiling = true;
            bullet.GetComponent<BoxCollider2D>().size = new Vector2(3.2f, 2.8f);

            bullet.AddComponent<BoxCollider2D>();
            bullet.GetComponent<BoxCollider2D>().isTrigger = true;
            bullet.GetComponent<BoxCollider2D>().size = new Vector2(3.2f, 2.8f);

            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            bullet.transform.localScale = new Vector3(0.4f, 0.4f);
            bullet.transform.position = new Vector3(bulletAnt.transform.position.x, bulletAnt.transform.position.y);

            if (angle * Mathf.Rad2Deg < -90)
            {
                bullet.transform.Rotate(0.0f, 0.0f, -90.0f - (angle * Mathf.Rad2Deg));
            }
            else
            {
                bullet.transform.Rotate(0.0f, 0.0f, -90.0f + (angle * Mathf.Rad2Deg));
            }

            bullets++;
            attackTimer = 0f;
            attacking = true;
        }

        if (bullets == 3)
        {
            attacking = false;
            if (attackCooldown > 200f)
            {
                bullets = 0;
                attackCooldown = 0f;
            }
            attackCooldown++;
        }

        if (!attacking)
        {
            
            if (!calculateAngle)
            {
                angle = bulletAnt.transform.rotation.eulerAngles.z;
                if (angle > 180)
                {
                    angle = angle - 360f;
                }

                angle *= Mathf.Deg2Rad;

                if (attackTimer > 0)
                {
                    calculateAngle = true;
                }
            }
            float x = Mathf.Cos(angle) * velocity;
            float y = Mathf.Sin(angle) * velocity;
            if(angle * Mathf.Rad2Deg < -90)
            {
                y *= -1;
            }
            
            bulletAnt.transform.position += new Vector3(x, y);
        }

        attackTimer++;
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (firstExit)
        {
            if (collision.tag == "Ground")
            {
                bulletAnt.transform.Rotate(0.0f, 180.0f, 0.0f);
                velocity *= -1;

                Debug.Log("Exit");
                firstEnter = false;
            }
        }

        firstExit = true;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(attackTimer > 1.0f)
        {
            checkEnter = true;
        }

        if(checkEnter && firstEnter)
        {
            if (collision.tag == "Ground")
            {
                bulletAnt.transform.Rotate(0.0f, 180.0f, 0.0f);
                velocity *= -1;

                Debug.Log("Enter");
                firstExit = false;

            }
        }
    
        firstEnter = true;
    }
    
}
