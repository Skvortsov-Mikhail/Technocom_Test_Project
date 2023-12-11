using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField] protected string m_itemName;
    public string ItemName => m_itemName;

    [SerializeField] protected string m_uniqueId;
    public string Id => m_uniqueId;

    [SerializeField] protected int m_value;
    public int Value => m_value;

    [SerializeField] protected float m_cost;
    public float Cost => m_cost;

    [SerializeField] protected Button _buyButton;

    [SerializeField] private TMP_Text m_title;
    [SerializeField] private TMP_Text m_valueText;
    [SerializeField] private TMP_Text m_costText;

    protected virtual void Start()
    {
        if (m_title != null) m_title.text = m_itemName;
        if (m_valueText != null) m_valueText.text = m_value.ToString();
        if (m_costText != null) m_costText.text = m_cost.ToString();

        _buyButton.onClick.AddListener(PressBuyButton);
    }

    protected virtual void PressBuyButton() { }
}