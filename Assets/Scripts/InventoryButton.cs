using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject PlayerInventory;
    [SerializeField] private GameObject ChestInventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void logToPlayer(int amount) {
        ChestInventory.GetComponent<Inventory>().removeLog(amount);
        PlayerInventory.GetComponent<Inventory>().addLog(amount);
    }

    public void logToChest(int amount) {
        PlayerInventory.GetComponent<Inventory>().removeLog(amount);
        ChestInventory.GetComponent<Inventory>().addLog(amount);
    }

    public void stoneToPlayer(int amount) {
        PlayerInventory.GetComponent<Inventory>().addStone(amount);
        ChestInventory.GetComponent<Inventory>().removeStone(amount);
    }

    public void stoneToChest(int amount) {
        ChestInventory.GetComponent<Inventory>().addStone(amount); 
        PlayerInventory.GetComponent<Inventory>().removeStone(amount);
    }
}
