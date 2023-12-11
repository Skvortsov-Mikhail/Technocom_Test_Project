using UnityEngine;
using Zenject;

public class StoresInstaller : MonoInstaller
{
    [SerializeField] private MoneyStore m_moneyStore;
    [SerializeField] private TicketsStore m_ticketsStore;

    public override void InstallBindings()
    {
        BindStores();
    }

    private void BindStores()
    {
        Container.
            Bind<MoneyStore>().FromInstance(m_moneyStore).AsSingle();

        Container.
            Bind<TicketsStore>().FromInstance(m_ticketsStore).AsSingle();
    }
}