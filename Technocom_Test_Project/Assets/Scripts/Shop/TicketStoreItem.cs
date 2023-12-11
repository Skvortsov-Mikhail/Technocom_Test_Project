using TMPro;
using UnityEngine;
using Zenject;

public class TicketStoreItem : StoreItem
{
    [SerializeField] private int m_unlockLevel;
    public int UnlockLevel => m_unlockLevel;

    [SerializeField] private GameObject m_iconLocker;
    [SerializeField] private GameObject m_buttonLocker;

    [SerializeField] private TMP_Text _unlockLevelText;

    private TicketsStore _ticketsStore;
    [Inject]
    public void Construct(TicketsStore ticketsStore)
    {
        _ticketsStore = ticketsStore;
    }

    protected override void Start()
    {
        base.Start();

        _unlockLevelText.text = "LV. " + m_unlockLevel.ToString();

        m_buttonLocker.SetActive(false);

        m_iconLocker.SetActive(true);
        _buyButton.interactable = !m_iconLocker.activeSelf;
    }

    protected override void PressBuyButton()
    {
        if (_ticketsStore.DoPurchase(this) == true)
        {
            m_buttonLocker.SetActive(true);
        }
    }

    public void UnlockItem()
    {
        m_iconLocker.SetActive(false);
        _buyButton.interactable = !m_iconLocker.activeSelf;
    }
}