using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public TMP_Text currencyText;
    public int startingMoney = 100000;
    private int currentMoney;

    void Awake() { Instance = this; }

    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("Money", startingMoney);
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        PlayerPrefs.SetInt("Money", currentMoney);
        UpdateUI();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney < amount) return false;
        currentMoney -= amount;
        PlayerPrefs.SetInt("Money", currentMoney);
        UpdateUI();
        return true;
    }

    void UpdateUI()
    {
        currencyText.text = currentMoney.ToString("N0");
    }
}
