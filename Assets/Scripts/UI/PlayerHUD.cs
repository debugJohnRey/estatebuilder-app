using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text nameDisplay;
    [SerializeField] private Image profileIcon;
    [SerializeField] private Image hudBackground;

    [Header("Icons")]
    [SerializeField] private Sprite maleIcon;
    [SerializeField] private Sprite femaleIcon;

    void Start()
    {
        // 1. Retrieve the saved data
        string savedName = PlayerPrefs.GetString("PlayerName", "New Player");
        string savedGender = PlayerPrefs.GetString("PlayerGender", "Male");

        // 2. Display the name
        if (nameDisplay != null)
        {
            nameDisplay.text = string.IsNullOrEmpty(savedName) ? "Guest" : savedName;
        }

        // 3. Set the profile icon based on gender
        if (profileIcon != null)
        {
            profileIcon.sprite = (savedGender == "Male") ? maleIcon : femaleIcon;
        }
    }
} // Isang bracket lang dapat dito para isara ang Class