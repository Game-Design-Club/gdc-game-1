using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
	[SerializeField]
	float speed = 11f;
	[SerializeField]
	GameObject player;
    [SerializeField]
    EnemyVision FOV;
    private void FixedUpdate()
    {
        if(FOV.getPlayerSighted())
		{
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(this.player.transform.position.x, this.player.transform.position.y), speed * Time.deltaTime);
            float plrDistance = this.player.transform.position.x - transform.position.x;
            if (plrDistance < 0f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(plrDistance > 0f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
		}
    }
}
