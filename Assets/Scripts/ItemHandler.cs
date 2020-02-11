using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] string itemName = "Sword";

    private PlayerPrefs playerPrefs = PlayerPrefs.GetInstance();

    private Transform item;
    private Text pickUpText;

    private float bounceSpeed = 2f;
    private float yPos;
    private bool goingUp;

    private bool canPickUp;
    private float pickTextTimer = 0f;
    private float pickTextCoolDown = 0.5f;

    void Start()
    {
        item = transform.Find("SwordItem");
        pickUpText = transform.Find("PickUpItem").GetComponent<Text>();
        pickUpText.text = "Press " + playerPrefs.Use + " to pick up";
        yPos = item.position.y;
        goingUp = true;
        canPickUp = false;
        pickUpText.text = pickUpText.text + " " + itemName;
    }

    void Update()
    {
        if (canPickUp)
        {
            if (pickTextTimer >= pickTextCoolDown)
                pickUpText.enabled = true;

            if (Input.GetKey(playerPrefs.Use))
            {
                // Add inventory management here.
                Destroy(gameObject);
            }
            pickTextTimer += Time.deltaTime;
        }
        else if (pickUpText.enabled)
            pickUpText.enabled = false;

        if (!canPickUp && pickTextTimer > 0f)
            pickTextTimer = 0f;
    }

    void FixedUpdate()
    {
        ItemBounce();
    }

    private void ItemBounce()
    {
        if (goingUp && item.position.y < yPos + 0.8f)
            item.Translate(Vector2.up * bounceSpeed * Time.deltaTime, Space.World);
        else if (goingUp)
            goingUp = false;
        else if (!goingUp && item.position.y > yPos)
            item.Translate(Vector2.down * bounceSpeed * Time.deltaTime, Space.World);
        else
            goingUp = true;
    }

    public void setPickUp(bool canPickUp)
    {
        this.canPickUp = canPickUp;
    }
}
