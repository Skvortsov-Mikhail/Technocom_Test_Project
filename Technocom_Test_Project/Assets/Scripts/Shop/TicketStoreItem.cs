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

    private bool m_locked = true;

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

        m_iconLocker.SetActive(m_locked);
        _buyButton.interactable = !m_locked;

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
        if (m_locked == false) return;

        m_locked = false;

        m_iconLocker.SetActive(false);
        _buyButton.interactable = true;
    }
}