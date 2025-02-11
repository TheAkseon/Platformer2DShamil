using TMPro;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    public TextMeshProUGUI CountMoneyText;

    public int CountMoney;

    private void Start()
    {
        CountMoneyText.text = CountMoney.ToString();
    }

    public void UpdateMoney()
    {
        CountMoney += 1;
        CountMoneyText.text = CountMoney.ToString();
    }
}
