using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Bugs:
 * If player too close to the ground collision, enemies still detect
 * Can be detected horizontally through vertical ground
 **/

public class EnemyVision : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D hitbox;
    [SerializeField]
    private GameObject player;
    private BoxCollider2D playerBox;
    private bool playerSighted;
    private List<RaycastHit2D> results;
    private ContactFilter2D filter;
    private void Start()
    {
        playerSighted = false;
        playerBox = (BoxCollider2D)player.GetComponent(typeof(BoxCollider2D));
        results = new List<RaycastHit2D>();
    }

    public bool getPlayerSighted()
    {
        return playerSighted;
    }

    private bool groundBetween(List<RaycastHit2D> results)
    {
        foreach (RaycastHit2D result in results)
        {
            if (result.collider.gameObject.CompareTag("Player"))
            {
                return false;
            }
            else if (result.collider.gameObject.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        if (hitbox.IsTouching(playerBox))
        {
            results = new List<RaycastHit2D>();
            //detecting itself instead of next object
            Physics2D.Raycast(hitbox.transform.position, player.transform.position, filter, results, hitbox.radius);
            https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
            results.Sort((x, y) => x.distance.CompareTo(y.distance));
            if (groundBetween(results))
            {
                playerSighted = false;
                print("Oh no");
            }
            else {
                playerSighted = true;
                print("Die");
            }
        }
    }
}