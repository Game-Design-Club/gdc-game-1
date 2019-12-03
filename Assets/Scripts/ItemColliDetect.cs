using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColliDetect : MonoBehaviour
{
    private ItemHandler itemHandler;

    void Start()
    {
        itemHandler = transform.parent.GetComponent<ItemHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemHandler.setPickUp(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        itemHandler.setPickUp(false);
    }
}
