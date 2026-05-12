using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public GameObject objectToShow; // Drag Cottage here
    public GameObject buyButton;    // Drag BuyLotBtn here

    private void Start()
    {
        // Everything starts hidden
        if(objectToShow != null) objectToShow.SetActive(false);
        if(buyButton != null) buyButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToShow.SetActive(true);
            buyButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToShow.SetActive(false);
            buyButton.SetActive(false);
        }
    }
}