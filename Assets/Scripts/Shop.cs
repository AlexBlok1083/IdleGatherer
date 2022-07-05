using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopMenuText;
    [SerializeField] private GameObject PlayerInventory;

    private bool isShopActive = false;
    private bool isCollide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This if statement opens and closes the shop when E is presed and collides with te player.
        if (isCollide && Input.GetKeyDown(KeyCode.E))
        {
            showHideInv();
        }

        // This if statement closes the shop when is does nog collide with the player.
        if (isCollide == false)
        {
            hideOnExit();
        }
    }

    public void showHideInv()
    {
        if (isShopActive == false)
        {
            ShopMenuText.SetActive(true);
            isShopActive = true;
        }
        else if (isShopActive)
        {
            ShopMenuText.SetActive(false);
            isShopActive = false;
        }
    }

    private void hideOnExit() {
        ShopMenuText.SetActive(false);
        isShopActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            isCollide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            isCollide = false;
        }
    }

    public void sellLogBtn(int amount) {
        PlayerInventory.GetComponent<Inventory>().addGold(amount/10);
        PlayerInventory.GetComponent<Inventory>().removeLog(amount);
    }

    public void sellStoneBtn(int amount) {
        PlayerInventory.GetComponent<Inventory>().addGold(amount/5);
        PlayerInventory.GetComponent<Inventory>().removeStone(amount);
    }
}
