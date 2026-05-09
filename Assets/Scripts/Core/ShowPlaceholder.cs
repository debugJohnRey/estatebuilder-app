using UnityEngine;

public class ShowPlaceholder : MonoBehaviour
{
    public GameObject ghostHouse; 

    private void Start()
    {
        // This ensures the house is hidden when you first press Play
        if (ghostHouse != null) ghostHouse.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ghostHouse.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) ghostHouse.SetActive(false);
    }
}