using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text nameDisplay;
    [SerializeField] private Image profileIcon;

    [Header("Icons")]
    [SerializeField] private Sprite maleIcon;
    [SerializeField] private Sprite femaleIcon;

    void Start()
    {
        // 1. Retrieve the saved data
        string savedName = PlayerPrefs.GetString("PlayerName", "Player");
        string savedGender = PlayerPrefs.GetString("PlayerGender", "Male");

        // 2. Display the name
        if (nameDisplay != null)
        {
            nameDisplay.text = savedName;
        }

        // 3. Set the profile icon based on gender
        if (profileIcon != null)
        {
            if (savedGender == "Male")
            {
                profileIcon.sprite = maleIcon;
            }
            else
            {
                profileIcon.sprite = femaleIcon;
            }
        }
    }
}