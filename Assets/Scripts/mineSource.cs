using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineSource : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject PlayerInventory;

    private bool isCollide;
    private int logMineAmount = 1;
    private int stoneMineAmount = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide && Input.GetKeyDown(KeyCode.Space) && item.name.Equals("Logs")) {
            PlayerInventory.GetComponent<Inventory>().addLog(logMineAmount);
        }

        if (isCollide && Input.GetKeyDown(KeyCode.Space) && item.name.Equals("Stone")) {
            PlayerInventory.GetComponent<Inventory>().addStone(stoneMineAmount);
        }
    }

    // These functions change a bool when the gameobject with the name Player enters or exits the minesource.
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
