using UnityEngine;
using TMPro;

public class NumbersView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leftColumn;
    [SerializeField] private TextMeshProUGUI _centralColumn;
    [SerializeField] private TextMeshProUGUI _rightColumn;

    public void SetLeftColumnValue(int value)
    {
        _leftColumn.text = value.ToString();
    }

    public void SetCentralColumnValue(int value)
    {
        _centralColumn.text = value.ToString();
    }

    public void SetRightColumnValue(int value)
    {
        _rightColumn.text = value.ToString();
    }
}
