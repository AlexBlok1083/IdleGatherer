using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject log;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject invTextName;
    [SerializeField] private GameObject PlayerTextInv;
    [SerializeField] private GameObject ChestInventory;
    [SerializeField] private GameObject ShopMenuText;

    private int goldAmount = 0;
    private int logAmount = 0;
    private int stoneAmount = 0;
    private bool isInvActive = false;

    private int logAmountChest;
    private int stoneAmountChest;
    private int logAmountPlayer;
    private int stoneAmountPlayer;


    void Start() {

    }


    void Update() {
        updateInventory();
        invActiveCheck();

        if ((invTextName.name.Equals("TextChestInv") && isInvActive) || (ShopMenuText.activeSelf)) {
            PlayerTextInv.SetActive(true);
            isInvActive = true;
        }
        
        
        if (invTextName.name.Equals("TextChestInv")) {
            logAmountChest = logAmount;
            stoneAmountChest = stoneAmount;
        }
        if (invTextName.name.Equals("TextPlayerInv")) {
            logAmountPlayer = logAmount;
            stoneAmountPlayer = stoneAmount;
        }
    }

    // This fuction updates the inventory with the resources amount.
    private void updateInventory() {
        log.GetComponent<Text>().text = "Logs: " + logAmount;
        stone.GetComponent<Text>().text = "Stone: " + stoneAmount;
        gold.GetComponent<Text>().text = "Gold: " + goldAmount;

    }

    // Checks if the inventory is active.
    private void invActiveCheck() {
        if (invTextName.activeSelf)
        {
            isInvActive = true;
        }
    }

    // This function shows or hides the inventory (Inv).
    public void showHideInv(string TextInv) {
        if (isInvActive == false && invTextName.name.Equals(TextInv)) {
            invTextName.SetActive(true);
            isInvActive = true;
        } else if (isInvActive && invTextName.name.Equals(TextInv)) {
            invTextName.SetActive(false);
            isInvActive = false;
        }
    }

    // This function hides the inventory on Exit.
    public void hideOnExit(string TextInv) {
        if (isInvActive && invTextName.name.Equals(TextInv)) {
            invTextName.SetActive(false);
            isInvActive = false;
        }
    }

    //
    //Public functions called by Button onClicks. Change from an inventory to another inventory.
    //
    
    public void logToPlayer(string amount) {
        if (amount == "All")
        {
            ChestInventory.GetComponent<InventoryButton>().logToPlayer(logAmountChest);
        }
        if (amount == "Half")
        {
            ChestInventory.GetComponent<InventoryButton>().logToPlayer(logAmountChest / 2);
        }
    }

    public void stoneToPlayer(string amount) {
        if (amount == "All") {
            ChestInventory.GetComponent<InventoryButton>().stoneToPlayer(stoneAmountChest);
        }
        if (amount == "Half") {
            ChestInventory.GetComponent<InventoryButton>().stoneToPlayer(stoneAmountChest / 2);
        }
    }

    public void logToChest(string amount) {
        if (amount == "All") {
            ChestInventory.GetComponent<InventoryButton>().logToChest(logAmountPlayer);
        }
        if (amount == "Half") {
            ChestInventory.GetComponent<InventoryButton>().logToChest(logAmountPlayer/2);
        }
    }

    public void stoneToChest(string amount) {
        if (amount == "All") {
            ChestInventory.GetComponent<InventoryButton>().stoneToChest(stoneAmountPlayer);
        }
        if (amount == "Half") {
            ChestInventory.GetComponent<InventoryButton>().stoneToChest(stoneAmountPlayer / 2);
        }
    }

    // add Gold
    public void addGold(int amount) {
        goldAmount += amount;
    }

    //
    // add and remove Log and Stone.
    //
    public void addLog(int i) {
        logAmount += i;
    }

    public void addStone(int i) {
        stoneAmount += i;    
    }

    public void removeLog(int i) {
        logAmount -= i;
    }

    public void removeStone(int i) {
        stoneAmount -= i;
    }
}
