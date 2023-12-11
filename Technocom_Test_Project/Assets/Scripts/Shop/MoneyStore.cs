using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Zenject;

public class MoneyStore : MonoBehaviour, IDetailedStoreListener
{
    private MoneyStoreItem[] m_items;

    private MoneyStoreItem _currentItem;

    private IStoreController _storeController;

    private TicketsController _ticketsController;

    [Inject]
    public void Construct(TicketsController ticketsController)
    {
        _ticketsController = ticketsController;
    }

    private void Start()
    {
        m_items = GetComponentsInChildren<MoneyStoreItem>();

        SetupBuilder();
    }

    private void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        foreach (var item in m_items)
        {
            builder.AddProduct(item.Id, item.Type);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    public void DoPurchase(MoneyStoreItem item)
    {
        _currentItem = item;

        _storeController.InitiatePurchase(_currentItem.Id);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;

        print("Successful initialization");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;

        print("Purchase Complete " + product.definition.id);

        if (product.definition.id == _currentItem.Id)
        {
            BuyTickets(_currentItem.Value);
        }

        return PurchaseProcessingResult.Complete;
    }

    private void BuyTickets(int value)
    {
        _ticketsController.AddTickets(value);
    }

    #region Errors
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        print("Purcahsed failed ");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("Purcahsed failed " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("Purcahsed failed " + error + message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("Purcahsed failed ");
    }
    #endregion
}