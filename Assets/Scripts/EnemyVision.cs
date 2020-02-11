using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private List<RaycastHit2D> rayList = new List<RaycastHit2D>();

    private void Start()
    {
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.up, 20f));
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.down, 20f));
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.left, 20f));
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.right, 20f));
        //towards TopRight
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.one, 20f));
        //towards Bottom Right
        rayList.Add(Physics2D.Raycast(transform.position, new Vector2(1,-1), 20f));
        //towards BottomLeft
        rayList.Add(Physics2D.Raycast(transform.position, new Vector2(-1, -1), 20f));
        //Towards TopLeft
        rayList.Add(Physics2D.Raycast(transform.position, new Vector2(-1,1), 20f));
        for(int i = 0; i < rayList.Count; i++)
        {
            //rayList[i].collider.;
        }
    }

    private void FixedUpdate()
    {
    }
}
