using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    [Header("Starting Money")]
    public int startingAmount = 100000;

    [Header("UI")]
    public TextMeshProUGUI currencyText;  // drag the Text (TMP) next to the coin icon

    private int _balance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
    }

    void Start()
    {
        _balance = startingAmount;
        RefreshUI();
    }

    public void AddMoney(int amount)
    {
        _balance += amount;
        RefreshUI();
    }

    public bool SpendMoney(int amount)
    {
        if (_balance < amount) return false;
        _balance -= amount;
        RefreshUI();
        return true;
    }

    public int GetBalance() => _balance;

    void RefreshUI()
    {
        if (currencyText != null)
            currencyText.text = _balance.ToString("N0");   // "100,000"
    }
}