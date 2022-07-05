using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isCollide = false;
    [SerializeField] private GameObject ChestInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This if statement opens and closes the chest inventory when E is presed and collides with te player.
        if (isCollide && Input.GetKeyDown(KeyCode.E)) {
            ChestInventory.GetComponent<Inventory>().showHideInv("TextChestInv");
        }
        
        // This if statement closes the chest inventory when is does nog collide with the player.
        if (isCollide == false) {
            ChestInventory.GetComponent<Inventory>().hideOnExit("TextChestInv");
        }
    }

    // These functions change a bool when the gameobject with the name Player enters or exits the chest.
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
}
