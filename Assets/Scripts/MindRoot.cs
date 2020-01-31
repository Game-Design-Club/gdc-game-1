using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindRoot : MonoBehaviour
{
    private GameObject player;
    private GameObject vine;
    private GameObject mindRoot;

    private bool startAttack;
    private bool beginAttack;
    private bool retractAttack;
    private bool endAttack;
    private bool attacking = false;
    private bool rotated = false;
    private float attackTimer = 0f;
    private float resetTimer = 0f;
    private float cooldownTimer = 0f;
    private float vineAngle;
    private bool created = false;

    private Sprite[] sprites;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mindRoot = GameObject.FindGameObjectWithTag("MindRoot");

        sprites = Resources.LoadAll<Sprite>("Vine 1.0");
    }

    private void FixedUpdate()
    {
        Attack();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            startAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            startAttack = false;
        }
    }

    public float RotateVineToPlayer()
    {
        Vector3 targ = player.transform.position;
        targ.z = 0f;
        Vector3 objectPos = vine.transform.position;
        targ.x -=  objectPos.x;
        targ.y -=  objectPos.y;
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        angle -= 180;
        return angle;
    }

    private void Attack()
    {
        if (startAttack)
        {
            attacking = true;
        }
        if (attacking)
        {
            if ((startAttack || beginAttack) && !retractAttack && !endAttack)
            {
                
                if (!created)
                { 
                    vine = new GameObject("vine");
                    vine.AddComponent<BoxCollider2D>();
                    vine.AddComponent<SpriteRenderer>();
                    vine.GetComponent<SpriteRenderer>().sprite = sprites[0];
                    vine.AddComponent<MindRoot>();
                    vine.GetComponent<BoxCollider2D>().autoTiling = true;
                    vine.GetComponent<BoxCollider2D>().size = new Vector2(3.6f, 4.5f);

                    vine.transform.localScale = new Vector3(0.25f, 0.25f);
                    vine.transform.position = new Vector3(mindRoot.transform.position.x, mindRoot.transform.position.y);

                    created = true;
                }
                

                if (!rotated)
                {
                    vineAngle = RotateVineToPlayer();
                    vine.transform.Rotate(0.0f, 0.0f, vineAngle);

                    rotated = true;
                }

                resetTimer = 0f;

                beginAttack = true;
                retractAttack = false;

                attackTimer += Time.deltaTime * 20;
                if (attackTimer < 10.0f)
                {
                    vine.SetActive(true);
                    
                }
                else if (attackTimer < 20.0f)
                {
                    vine.transform.localScale += new Vector3(0.05f, 0f);

                    if (vineAngle <= 0 && vineAngle >= -5)
                    {
                        vine.transform.position += new Vector3(-0.10f, 0f);
                    }
                    else if (vineAngle <= -5 && vineAngle >= -15)
                    {
                        vine.transform.position += new Vector3(-0.09f, 0.01f);
                    }
                    else if (vineAngle <= -15 && vineAngle >= -25)
                    {
                        vine.transform.position += new Vector3(-0.08f, 0.02f);
                    }
                    else if (vineAngle <= -25 && vineAngle >= -35)
                    {
                        vine.transform.position += new Vector3(-0.07f, 0.03f);
                    }
                    else if (vineAngle <= -35 && vineAngle >= -45)
                    {
                        vine.transform.position += new Vector3(-0.06f, 0.04f);
                    }
                    else if (vineAngle <= -45 && vineAngle >= -55)
                    {
                        vine.transform.position += new Vector3(-0.04f, 0.06f);
                    }
                    else if (vineAngle <= -55 && vineAngle >= -65)
                    {
                        vine.transform.position += new Vector3(-0.03f, 0.07f);
                    }
                    else if (vineAngle <= -65 && vineAngle >= -75)
                    {
                        vine.transform.position += new Vector3(-0.02f, 0.08f);
                    }
                    else if (vineAngle <= -75 && vineAngle >= -85)
                    {
                        vine.transform.position += new Vector3(-0.01f, 0.09f);
                    }
                    else if (vineAngle <= -85 && vineAngle >= -95)
                    {
                        vine.transform.position += new Vector3(0f, 0.10f);
                    }
                    else if (vineAngle <= -95 && vineAngle >= -105)
                    {
                        vine.transform.position += new Vector3(0.01f, 0.09f);
                    }
                    else if (vineAngle <= -105 && vineAngle >= -115)
                    {
                        vine.transform.position += new Vector3(0.02f, 0.08f);
                    }
                    else if (vineAngle <= -115 && vineAngle >= -125)
                    {
                        vine.transform.position += new Vector3(0.03f, 0.07f);
                    }
                    else if (vineAngle <= -125 && vineAngle >= -135)
                    {
                        vine.transform.position += new Vector3(0.04f, 0.06f);
                    }
                    else if (vineAngle <= -135 && vineAngle >= -145)
                    {
                        vine.transform.position += new Vector3(0.06f, 0.04f);
                    }
                    else if (vineAngle <= -145 && vineAngle >= -155)
                    {
                        vine.transform.position += new Vector3(0.07f, 0.03f);
                    }
                    else if (vineAngle <= -155 && vineAngle >= -165)
                    {
                        vine.transform.position += new Vector3(0.08f, 0.02f);
                    }
                    else if (vineAngle <= -165 && vineAngle >= -175)
                    {
                        vine.transform.position += new Vector3(0.09f, 0.01f);
                    }
                    else if (vineAngle <= -175 && vineAngle >= -185)
                    {
                        vine.transform.position += new Vector3(0.10f, 0f);
                    }
                    else if (vineAngle <= -185 && vineAngle >= -195)
                    {
                        vine.transform.position += new Vector3(0.09f, -0.01f);
                    }
                    else if (vineAngle <= -195 && vineAngle >= -205)
                    {
                        vine.transform.position += new Vector3(0.08f, -0.02f);
                    }
                    else if (vineAngle <= -205 && vineAngle >= -215)
                    {
                        vine.transform.position += new Vector3(0.07f, -0.03f);
                    }
                    else if (vineAngle <= -215 && vineAngle >= -225)
                    {
                        vine.transform.position += new Vector3(0.06f, -0.04f);
                    }
                    else if (vineAngle <= -225 && vineAngle >= -235)
                    {
                        vine.transform.position += new Vector3(0.04f, -0.06f);
                    }
                    else if (vineAngle <= -235 && vineAngle >= -245)
                    {
                        vine.transform.position += new Vector3(0.03f, -0.07f);
                    }
                    else if (vineAngle <= -245 && vineAngle >= -255)
                    {
                        vine.transform.position += new Vector3(0.02f, -0.08f);
                    }
                    else if (vineAngle <= -255 && vineAngle >= -265)
                    {
                        vine.transform.position += new Vector3(0.01f, -0.09f);
                    }
                    else if (vineAngle <= -265 && vineAngle >= -275)
                    {
                        vine.transform.position += new Vector3(0f, -0.10f);
                    }
                    else if (vineAngle <= -275 && vineAngle >= -285)
                    {
                        vine.transform.position += new Vector3(-0.01f, -0.09f);
                    }
                    else if (vineAngle <= -285 && vineAngle >= -295)
                    {
                        vine.transform.position += new Vector3(-0.02f, -0.08f);
                    }
                    else if (vineAngle <= -295 && vineAngle >= -305)
                    {
                        vine.transform.position += new Vector3(-0.03f, -0.07f);
                    }
                    else if (vineAngle <= -305 && vineAngle >= -315)
                    {
                        vine.transform.position += new Vector3(-0.04f, -0.06f);
                    }
                    else if (vineAngle <= -315 && vineAngle >= -325)
                    {
                        vine.transform.position += new Vector3(-0.06f, -0.04f);
                    }
                    else if (vineAngle <= -325 && vineAngle >= -335)
                    {
                        vine.transform.position += new Vector3(-0.07f, -0.03f);
                    }
                    else if (vineAngle <= -335 && vineAngle >= -345)
                    {
                        vine.transform.position += new Vector3(-0.08f, -0.02f);
                    }
                    else if (vineAngle <= -345 && vineAngle >= -355)
                    {
                        vine.transform.position += new Vector3(-0.09f, -0.01f);
                    }
                    else if (vineAngle <= -355 && vineAngle >= -360)
                    {
                        vine.transform.position += new Vector3(-0.10f, 0f);
                    }
                }
                else
                {
                    attackTimer = 0;

                    beginAttack = false;
                    retractAttack = true;
                }
            }
            else if (retractAttack)
            {
                resetTimer += Time.deltaTime * 10;

                if (resetTimer < 10.0f)
                {
                    
                }
                else if (resetTimer < 20.125f)
                {
                    vine.transform.localScale += new Vector3(-0.025f, 0f);

                    if (vineAngle <= 0 && vineAngle >= -5)
                    {
                        vine.transform.position += new Vector3(0.05f, 0f);
                    }
                    else if (vineAngle <= -5 && vineAngle >= -15)
                    {
                        vine.transform.position += new Vector3(0.045f, -0.005f);
                    }
                    else if (vineAngle <= -15 && vineAngle >= -25)
                    {
                        vine.transform.position += new Vector3(0.04f, -0.01f);
                    }
                    else if (vineAngle <= -25 && vineAngle >= -35)
                    {
                        vine.transform.position += new Vector3(0.035f, -0.015f);
                    }
                    else if (vineAngle <= -35 && vineAngle >= -45)
                    {
                        vine.transform.position += new Vector3(0.03f, -0.02f);
                    }
                    else if (vineAngle <= -45 && vineAngle >= -55)
                    {
                        vine.transform.position += new Vector3(0.02f, -0.03f);
                    }
                    else if (vineAngle <= -55 && vineAngle >= -65)
                    {
                        vine.transform.position += new Vector3(0.015f, -0.035f);
                    }
                    else if (vineAngle <= -65 && vineAngle >= -75)
                    {
                        vine.transform.position += new Vector3(0.01f, -0.04f);
                    }
                    else if (vineAngle <= -75 && vineAngle >= -85)
                    {
                        vine.transform.position += new Vector3(0.005f, -0.045f);
                    }
                    else if (vineAngle <= -85 && vineAngle >= -95)
                    {
                        vine.transform.position += new Vector3(0f, -0.05f);
                    }
                    else if (vineAngle <= -95 && vineAngle >= -105)
                    {
                        vine.transform.position += new Vector3(-0.005f, -0.045f);
                    }
                    else if (vineAngle <= -105 && vineAngle >= -115)
                    {
                        vine.transform.position += new Vector3(-0.01f, -0.04f);
                    }
                    else if (vineAngle <= -115 && vineAngle >= -125)
                    {
                        vine.transform.position += new Vector3(-0.015f, -0.035f);
                    }
                    else if (vineAngle <= -125 && vineAngle >= -135)
                    {
                        vine.transform.position += new Vector3(-0.02f, -0.03f);
                    }
                    else if (vineAngle <= -135 && vineAngle >= -145)
                    {
                        vine.transform.position += new Vector3(-0.03f, -0.02f);
                    }
                    else if (vineAngle <= -145 && vineAngle >= -155)
                    {
                        vine.transform.position += new Vector3(-0.035f, -0.015f);
                    }
                    else if (vineAngle <= -155 && vineAngle >= -165)
                    {
                        vine.transform.position += new Vector3(-0.04f, -0.01f);
                    }
                    else if (vineAngle <= -165 && vineAngle >= -175)
                    {
                        vine.transform.position += new Vector3(-0.045f, -0.005f);
                    }
                    else if (vineAngle <= -175 && vineAngle >= -185)
                    {
                        vine.transform.position += new Vector3(-0.05f, 0f);
                    }
                    else if (vineAngle <= -185 && vineAngle >= -195)
                    {
                        vine.transform.position += new Vector3(-0.045f, 0.005f);
                    }
                    else if (vineAngle <= -195 && vineAngle >= -205)
                    {
                        vine.transform.position += new Vector3(-0.04f, 0.01f);
                    }
                    else if (vineAngle <= -205 && vineAngle >= -215)
                    {
                        vine.transform.position += new Vector3(-0.035f, 0.015f);
                    }
                    else if (vineAngle <= -215 && vineAngle >= -225)
                    {
                        vine.transform.position += new Vector3(-0.03f, 0.02f);
                    }
                    else if (vineAngle <= -225 && vineAngle >= -235)
                    {
                        vine.transform.position += new Vector3(-0.02f, 0.03f);
                    }
                    else if (vineAngle <= -235 && vineAngle >= -245)
                    {
                        vine.transform.position += new Vector3(-0.015f, 0.035f);
                    }
                    else if (vineAngle <= -245 && vineAngle >= -255)
                    {
                        vine.transform.position += new Vector3(-0.01f, 0.04f);
                    }
                    else if (vineAngle <= -255 && vineAngle >= -265)
                    {
                        vine.transform.position += new Vector3(-0.005f, 0.045f);
                    }
                    else if (vineAngle <= -265 && vineAngle >= -275)
                    {
                        vine.transform.position += new Vector3(0f, 0.05f);
                    }
                    else if (vineAngle <= -275 && vineAngle >= -285)
                    {
                        vine.transform.position += new Vector3(0.005f, 0.045f);
                    }
                    else if (vineAngle <= -285 && vineAngle >= -295)
                    {
                        vine.transform.position += new Vector3(0.01f, 0.04f);
                    }
                    else if (vineAngle <= -295 && vineAngle >= -305)
                    {
                        vine.transform.position += new Vector3(0.015f, 0.035f);
                    }
                    else if (vineAngle <= -305 && vineAngle >= -315)
                    {
                        vine.transform.position += new Vector3(0.02f, 0.03f);
                    }
                    else if (vineAngle <= -315 && vineAngle >= -325)
                    {
                        vine.transform.position += new Vector3(0.03f, 0.02f);
                    }
                    else if (vineAngle <= -325 && vineAngle >= -335)
                    {
                        vine.transform.position += new Vector3(0.035f, 0.015f);
                    }
                    else if (vineAngle <= -335 && vineAngle >= -345)
                    {
                        vine.transform.position += new Vector3(0.04f, 0.01f);
                    }
                    else if (vineAngle <= -345 && vineAngle >= -355)
                    {
                        vine.transform.position += new Vector3(0.045f, 0.005f);
                    }
                    else if (vineAngle <= -355 && vineAngle >= -360)
                    {
                        vine.transform.position += new Vector3(0.05f, 0f);
                    }
                }
                else
                {
                    vine.transform.localScale = new Vector3(0.25f, 0.25f);

                    resetTimer = 0f;

                    retractAttack = false;
                    endAttack = true;
                }
            }
            else if (endAttack)
            {
                vine.SetActive(false);
                cooldownTimer += Time.deltaTime * 20;
                if (cooldownTimer > 50.0f)
                {
                    cooldownTimer = 0f;
                    endAttack = false;
                    attacking = false;
                    rotated = false;
                    vine.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    vine.transform.position = new Vector3(mindRoot.transform.position.x, mindRoot.transform.position.y, 0f);

                    BoxCollider2D vineBox = vine.GetComponent<BoxCollider2D>();
                    vineBox.size = new Vector2(3.6f, 4.5f);
                }
            }
        }
    }
}
