using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
	[SerializeField]
	float speed = 11f;
	[SerializeField]
	GameObject player;

    private void FixedUpdate()
    {
        if(player != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y), speed * Time.deltaTime);
            float plrDistance = player.transform.position.x - transform.position.x;
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
