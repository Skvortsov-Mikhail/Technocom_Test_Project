using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

public class MoneyStoreItem : StoreItem
{
    [SerializeField] private ProductType m_type;
    public ProductType Type => m_type;

    private MoneyStore _moneyStore;
    [Inject]
    public void Construct(MoneyStore moneyStore)
    {
        _moneyStore = moneyStore;
    }

    protected override void PressBuyButton()
    {
        _moneyStore.DoPurchase(this);
    }
}