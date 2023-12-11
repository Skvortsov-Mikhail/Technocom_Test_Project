using UnityEngine;
using Zenject;

public class TicketsStore : MonoBehaviour
{
    private TicketStoreItem[] m_items;

    private TicketsController _ticketsController;

    [Inject]
    public void Construct(TicketsController ticketsController)
    {
        _ticketsController = ticketsController;
    }

    private void Start()
    {
        m_items = GetComponentsInChildren<TicketStoreItem>();
    }

    public bool DoPurchase(TicketStoreItem item)
    {
        if (_ticketsController.RemoveTickets((int)item.Cost) == true)
        {


            return true;
        }
        else
        {
            Debug.LogError("Not enough tickets to buy " + item.ItemName);
            return false;
        }
    }

    public void UpdateGoodsAvailability(int lastPassedLevel)
    {
        foreach (var item in m_items)
        {
            if (item.UnlockLevel <= lastPassedLevel)
            {
                item.UnlockItem();
            }
        }
    }
}