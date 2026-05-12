using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public GameObject placeholderHouse; // The transparent/ghost cottage
    public GameObject actualHouse;      // The real, solid house model
    public GameObject buyLotButton;
    public GameObject purchaseModal;
    
    private bool isBought = false;

    private void Start()
    {
        // Everything starts hidden
        if(placeholderHouse != null) placeholderHouse.SetActive(false);
        if(actualHouse != null) actualHouse.SetActive(false);
        if(buyLotButton != null) buyLotButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBought) return;

        if (other.CompareTag("Player"))
        {
            placeholderHouse.SetActive(true);
            buyLotButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isBought) return;

        if (other.CompareTag("Player"))
        {
            placeholderHouse.SetActive(false);
            buyLotButton.SetActive(false);
        }
    }

    public void BuyHouse()
    {
        isBought = true;
        
        // The Big Swap:
        placeholderHouse.SetActive(false); // Hide the ghost
        actualHouse.SetActive(true);       // Show the real house
        
        // Clean up UI
        buyLotButton.SetActive(false);
        purchaseModal.SetActive(false);
    }
}