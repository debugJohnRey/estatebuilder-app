using UnityEngine;

public class PurchaseSpot : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject buyButton;
    public GameObject selectionModal;

    [Header("House Options")]
    public GameObject houseA;
    public GameObject houseB;

    private Renderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        meshRenderer.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buyButton.SetActive(true);
            meshRenderer.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buyButton.SetActive(false);
            selectionModal.SetActive(false); // Close menu if they walk away
            meshRenderer.enabled = false;
        }
    }

    // Step 1: Called when clicking the main Buy Button
    public void OpenSelectionMenu()
    {
        selectionModal.SetActive(true);
        buyButton.SetActive(false);
    }

    // Step 2: Called when clicking House A button
    public void BuyHouseA()
    {
        FinalizePurchase(houseA);
    }

    // Step 3: Called when clicking House B button
    public void BuyHouseB()
    {
        FinalizePurchase(houseB);
    }

    private void FinalizePurchase(GameObject chosenHouse)
    {
        chosenHouse.SetActive(true);
        selectionModal.SetActive(false);
        this.gameObject.SetActive(false); // Remove the placeholder
    }
}