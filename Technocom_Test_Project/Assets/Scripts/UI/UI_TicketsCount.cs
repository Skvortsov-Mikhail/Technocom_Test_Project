using TMPro;
using UnityEngine;
using Zenject;

public class UI_TicketsCount : MonoBehaviour
{
    private TicketsController _ticketsController;

    [Inject]
    public void Construct(TicketsController ticketsController)
    {
        _ticketsController = ticketsController;
    }

    private TMP_Text _countText;

    private void Start()
    {
        _countText = GetComponentInChildren<TMP_Text>();

        _countText.text = _ticketsController.TicketsCount.ToString();

        _ticketsController.TicketsCountChanged += UpdateCountText;
    }
    private void OnDestroy()
    {
        _ticketsController.TicketsCountChanged -= UpdateCountText;
    }

    private void UpdateCountText(int value)
    {
        _countText.text = value.ToString();
    }
}