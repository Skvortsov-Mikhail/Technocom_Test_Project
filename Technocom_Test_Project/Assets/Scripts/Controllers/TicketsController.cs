using System;
using UnityEngine;

public class TicketsController : MonoBehaviour
{
    public Action<int> TicketsCountChanged;

    private int _ticketsCount;
    public int TicketsCount => _ticketsCount;

    public void AddTickets(int count)
    {
        _ticketsCount = Mathf.Clamp(_ticketsCount + count, 0, int.MaxValue);

        TicketsCountChanged?.Invoke(_ticketsCount);
    }

    public bool RemoveTickets(int count)
    {
        if (_ticketsCount - count < 0) return false;

        _ticketsCount -= count;

        TicketsCountChanged?.Invoke(_ticketsCount);

        return true;
    }
}