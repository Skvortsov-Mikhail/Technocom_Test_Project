using UnityEngine;
using Zenject;

public class LevelsInfo : MonoBehaviour
{
    private Level[] _levels;

    private TicketsStore _ticketsStore;
    [Inject]
    public void Construct(TicketsStore ticketsStore)
    {
        _ticketsStore = ticketsStore;
    }

    private void Start()
    {
        _levels = GetComponentsInChildren<Level>();

        SetLastPassedLevel(0);
    }

    public void SetLastPassedLevel(int number)
    {
        if (number >= _levels.Length) return;

        _levels[number].DisableLocker();

        _ticketsStore.UpdateGoodsAvailability(number);
    }
}