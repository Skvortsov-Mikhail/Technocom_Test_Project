using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private TicketsController m_ticketsController;
    [SerializeField] private DailyRewardManager m_dailyRewardManager;

    public override void InstallBindings()
    {
        Container.
            Bind<TicketsController>()
            .FromComponentInNewPrefab(m_ticketsController)
            .AsSingle();

        Container.
            Bind<DailyRewardManager>()
            .FromComponentInNewPrefab(m_dailyRewardManager)
            .AsSingle();
    }
}